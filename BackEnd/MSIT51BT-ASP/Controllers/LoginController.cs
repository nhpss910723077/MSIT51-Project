using Microsoft.AspNetCore.Mvc;
using System.Text;
using MSIT51BT_ASP.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using System.Text.Json;
using System.Net.Http;
using System.Net.Sockets;
using System.Collections.Specialized;
using System.Security.Policy;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

using Google.Apis.Auth;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace MSIT51BT_ASP.Controllers
{

    public class LoginController : Controller
    {
        private readonly Models.SqlContext _context;

        public LoginController(Models.SqlContext context)
        {
            _context = context;
        }
  
        //登入
        [HttpPost]
        public JsonResult DoLogin(string userEmail, string userPassword, string? bindCode)
        {
			string FinalPwd = Libraries.MyHelper.SecrectPwd(userEmail, userPassword);  //FinalPwd為加密最終結果

            var member = _context.Member
                .Where(x => x.Account == userEmail)
                .Where(x => x.Password == FinalPwd) //使用加密後的密碼去查詢
                .Select(x => x)
				.FirstOrDefault();

 
			if (member != null && member.VerifyStatus == true)
            {
				LineBind? lineBind = null;
				if (bindCode != null || bindCode != "")//傳入的字串有東西->查出是哪一組的LineCode
                {  
                    lineBind = _context.LineBind
							.Where(x => x.LineCode == bindCode)
							.FirstOrDefault();
				}

                if(lineBind != null && member.LineMemberNumber == null) { //有查到東西且這個人沒綁定
                    member.LineMemberNumber = lineBind.LineID; //把這組的LineID塞給他
                    member.ShoppingMoney += 200; //購物金多200
                    _context.Update(member);
					_context.SaveChangesAsync();

					return Json(new { result = "success", title = "登入成功!，已完成Line綁定", MemberID = member.ID });
                }
                else {
					return Json(new { result = "success", title = "登入成功!", MemberID = member.ID });
				}
            }
            else if (member != null && member.VerifyStatus == false) { return Json(new { result = "validerror", title = "此帳號還未開通" }); }
            else
            { return Json(new { result = "error", title = "發生錯誤" }); }

        }

        //註冊頁面，檢查DB是否有重複的帳號了
        [HttpPost]
        public JsonResult CheckEmail(string userEmail)
        {
            var q = _context.Member
                .Where(x => x.Account == userEmail)
                .Select(x => x);

            if (q.Count() == 1)
            {
                return Json(new { result = "exist", title = "資料庫已經存在此Email" });
            }
            else
            { return Json(new { result = "Notexist", title = "資料庫無此Email" }); }

        }

        //註冊
        [HttpPost]
        public async Task<JsonResult> DoRegister(string userEmail, string userPassword, string userName, string userPhone)

        {
            Member addMember = new Member();

            // 預設值
            addMember.LineBindCode = Libraries.MyHelper.GetRandomChar(30);
            addMember.ShoppingMoney = 0;
            addMember.VerifyCode = Libraries.MyHelper.GetRandomChar(30);
            addMember.VerifyStatus = false;
            addMember.PublicBookcase = false;
            addMember.Sort = 0;
            addMember.Enable = true;
            addMember.UpdateTime = DateTime.Now;
            addMember.CreateTime = DateTime.Now;
            //key 值
            addMember.Account = userEmail;
            addMember.Name = userName;
            addMember.Phone = userPhone;
            addMember.Password = Libraries.MyHelper.SecrectPwd(userEmail, userPassword);


            if (ModelState.IsValid)
            {
                _context.Add(addMember);
                await _context.SaveChangesAsync();

                //搜尋會員ID
                var q = _context.Member
                .Where(x => x.Account == userEmail)
                .Select(x => x.ID);

                //寄信
                string GoogleID = "m7852312@gmail.com"; //Google 發信帳號
                string TempPwd = "soup ocpf arme smjs"; //應用程式密碼
                string ReceiveMail = userEmail; //接收信箱
                string SmtpServer = "smtp.gmail.com";
                int SmtpPort = 587;
                MailMessage mms = new MailMessage();
                mms.From = new MailAddress(GoogleID, "ReadUse");
                mms.Subject = "ReadUse會員功能開通";
                mms.Body = $"親愛的會員{userName}您好，請點擊網址https://green-stone-07e8e6f10.4.azurestaticapps.net/valid/{q.ToArray()[0]}/{addMember.VerifyCode}以開通會員功能，並前往會員登入頁面。";
                mms.IsBodyHtml = true;
                mms.SubjectEncoding = Encoding.UTF8;
                mms.To.Add(new MailAddress(ReceiveMail));
                using (SmtpClient client = new SmtpClient(SmtpServer, SmtpPort))
                {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(GoogleID, TempPwd);
                    client.Send(mms); //寄出信件
                }
                return Json(new { result = "success", title = "送出成功" });
            }

            var ModelStateErrors = ModelState.Where(x => x.Value.Errors.Count > 0)
            .ToDictionary(k => k.Key, k => k.Value.Errors.Select(e => e.ErrorMessage).ToArray());

            return Json(new { result = "error", title = "發生錯誤", data = ModelStateErrors });
        }

        //驗證頁面
        public JsonResult DOverify(int memberID, string vcode)
        {
            var q = _context.Member
             .Where(x => x.ID == memberID)
             .Where(x => x.VerifyCode == vcode)
             .Select(x => x);

            Member editMember = q.FirstOrDefault();
            if (q.Count() == 1)
            {
                //VerifyStatus改成True
                if (ModelState.IsValid)
                {
                    try
                    {
                        editMember.VerifyStatus = true;

                        _context.Update(editMember);
                        _context.SaveChanges();

                        return Json(new { result = "success", title = "更新成功" });
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        return Json(new { result = "info", title = "更新失敗" });
                    }
                }
                return Json(new { result = "success", title = "送出成功" });
            }
            else
            {
                return Json(new { result = "error", title = "發生錯誤" });
            }
        }

        //忘記密碼頁面
        [HttpPost]
        public JsonResult ForgetPwd(string userEmail)
        {
            var q = _context.Member
                .Where(x => x.Account == userEmail);

            Member editMember = q.FirstOrDefault();


            if (editMember == null || editMember.Password == null)
            {
                return Json(new { result = "info", title = "查無此項目" });
            }
            if (ModelState.IsValid)
            {
                try
                {
                    //直接改DB的密碼
                    string NewPwd = Libraries.MyHelper.GetRandomChar(8);
                    editMember.Password = Libraries.MyHelper.SecrectPwd(userEmail, NewPwd);
                    _context.Update(editMember);
                    _context.SaveChanges();

                    //發信
                    string GoogleID = "m7852312@gmail.com"; //Google 發信帳號
                    string TempPwd = "soup ocpf arme smjs"; //應用程式密碼
                    string ReceiveMail = userEmail; //接收信箱
                    string SmtpServer = "smtp.gmail.com";
                    int SmtpPort = 587;
                    MailMessage mms = new MailMessage();
                    mms.From = new MailAddress(GoogleID, "ReadUse");
                    mms.Subject = "ReadUse更新密碼";
                    mms.Body = $"親愛的會員{q.ToArray()[0].Name}您好，您的新密碼為{NewPwd}，請點擊網址https://green-stone-07e8e6f10.4.azurestaticapps.net/login前往會員登入頁面。";
                    mms.IsBodyHtml = true;
                    mms.SubjectEncoding = Encoding.UTF8;
                    mms.To.Add(new MailAddress(ReceiveMail));
                    using (SmtpClient client = new SmtpClient(SmtpServer, SmtpPort))
                    {
                        client.EnableSsl = true;
                        client.Credentials = new NetworkCredential(GoogleID, TempPwd);
                        client.Send(mms); //寄出信件
                    }

                    return Json(new { result = "success", title = "更改密碼成功"});
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Json(new { result = "info", title = "更新失敗" });
                }
            }

            var ModelStateErrors = ModelState.Where(x => x.Value.Errors.Count > 0)
            .ToDictionary(k => k.Key, k => k.Value.Errors.Select(e => e.ErrorMessage).ToArray());

            return Json(new { result = "error", title = "發生錯誤", data = ModelStateErrors });
        }

        //我不是機器人      
        [HttpGet]
        public async Task<JsonResult> Robot(string token)
        {
            try
            {
                var client = new HttpClient();
                string baseUrl = "https://www.google.com/recaptcha/api/siteverify";
                string secret = "6LeF5lwoAAAAAOsCWSq8GDvUCYTUp9VK--mQqD40";            
                string urlWithParams = $"{baseUrl}?secret={secret}&response={token}";             
                var myresponse = await client.GetAsync(urlWithParams);                              
                var responseContent = await myresponse.Content.ReadAsStringAsync();
                return Json(new { result = "ROBOT", tt = responseContent });              
                                  
            }
            catch (Exception ex)
            {
                return Json(new { result = "error", title = "發生錯誤" });
            }
        }


        //Google第三方登入
        [HttpPost]
        public async Task<JsonResult> GoogleLogin(string userEmail, string userGoogle ,string userName)
        {
            var q = _context.Member
               .Where(x => x.Account == userEmail)
               .Select(x => x);

            if (q.Count() == 1)
            {
                if (q.ToArray()[0].GoogleMemberNumber==null) 
                {
                    //Edit
                    Member editMember = q.FirstOrDefault();
                    editMember.GoogleMemberNumber = userGoogle;
                    _context.Update(editMember);
                    await _context.SaveChangesAsync();
                    return Json(new { result = "exist", title = "資料庫已經存在此Email，幫他加上GoogleMemberNumber",MemberID= q.ToArray()[0].ID });
                }
            
                else
                {
                    return Json(new { result = "exist", title = "資料庫已經存在此Google會員", MemberID = q.ToArray()[0].ID });
                }
            }
            else  //資料庫無此Email 新增一筆 
            {

                Member addMember = new Member();
                // 預設值
                addMember.LineBindCode = Libraries.MyHelper.GetRandomChar(30);
                addMember.ShoppingMoney = 0;
                addMember.VerifyCode = Libraries.MyHelper.GetRandomChar(30);
                addMember.VerifyStatus = true;
                addMember.PublicBookcase = false;
                addMember.Sort = 0;
                addMember.Enable = true;
                addMember.UpdateTime = DateTime.Now;
                addMember.CreateTime = DateTime.Now;
                //key 值
                addMember.Account = userEmail;
                addMember.Name = userName;
                addMember.GoogleMemberNumber = userGoogle;
                //addMember.Phone = userPhone;

                if (ModelState.IsValid)
                {
                    _context.Add(addMember);
                    await _context.SaveChangesAsync();
                    var w = _context.Member
                        .Where(x => x.Account == userEmail)
                        .Select(x => x);
                    return Json(new { result = "success", title = "新增成功", MemberID = w.ToArray()[0].ID });
                }
                else 
                {
                     var ModelStateErrors = ModelState.Where(x => x.Value.Errors.Count > 0)
                .ToDictionary(k => k.Key, k => k.Value.Errors.Select(e => e.ErrorMessage).ToArray());

                return Json(new { result = "error", title = "發生錯誤", data = ModelStateErrors });
                }                        
            }
        }




    }
}
