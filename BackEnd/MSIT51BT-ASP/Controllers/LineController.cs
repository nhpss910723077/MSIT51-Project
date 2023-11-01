using Azure.Core;
using ECPay.Payment.Integration;
using isRock.LineBot;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MSIT51BT_ASP.Libraries;
using MSIT51BT_ASP.Models;
using System;
using System.Configuration;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MSIT51BT_ASP.Controllers {
	public class LineController : Controller {
		private readonly Models.SqlContext _context;
		private readonly string chanAccToken;
		private readonly isRock.LineBot.Bot lineBot;

		public LineController(Models.SqlContext context) {
			_context = context;
			chanAccToken = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
			lineBot = new isRock.LineBot.Bot(chanAccToken);
		}

		[HttpPost]
		public IActionResult Line() {
			using var sr = new StreamReader(Request.Body);
			var reqBody = sr.ReadToEndAsync().Result;
			var rcvMsg = isRock.LineBot.Utility.Parsing(reqBody);

			foreach (var e in rcvMsg.events) {
				if (!string.IsNullOrEmpty(e.message?.text)) {
					var replyToken = e.replyToken;
					var userId = e.source.userId;
					var userName = lineBot.GetUserInfo(userId).displayName;
					var userMsg = e.message.text;

					switch (userMsg) {
						case "會員中心":
							// 先查看用戶是否已綁定
							var member = _context.Member
								.Where(x => x.LineMemberNumber == userId)
								.FirstOrDefault();
							if (member == null) {
								LineBind lineBind = new LineBind() {
									LineID = userId,
									LineCode = MyHelper.GetRandomChar(30)
								};

								_context.Add(lineBind);
								_context.SaveChangesAsync();

								var btnTmpl = new isRock.LineBot.ButtonsTemplate() {
									altText = "請用手機檢視",
									text = " ",
									title = "請先綁定Line帳戶",
									thumbnailImageUrl = new Uri("https://green-stone-07e8e6f10.4.azurestaticapps.net/images/Logo.png"),
									actions = new List<isRock.LineBot.TemplateActionBase>() {
										new isRock.LineBot.UriAction() {
											label = "登入後綁定",
											uri = new Uri($"https://green-stone-07e8e6f10.4.azurestaticapps.net/login?bindCode={lineBind.LineCode}")
										}
									}
								};

								lineBot.ReplyMessage(replyToken, new TemplateMessage(btnTmpl));
							}
							else {
								var btnTmpl = new isRock.LineBot.ButtonsTemplate() {
									altText = "請用手機檢視",
									text = " ",
									title = "已完成綁定，可直接登入",
									thumbnailImageUrl = new Uri("https://green-stone-07e8e6f10.4.azurestaticapps.net/images/Logo.png"),
									actions = new List<isRock.LineBot.TemplateActionBase>() {
										new isRock.LineBot.UriAction() {
											label = "登入帳號",
											uri = new Uri("https://green-stone-07e8e6f10.4.azurestaticapps.net/login")
										}
									}
								};
								lineBot.ReplyMessage(replyToken, new TemplateMessage(btnTmpl));
							}
							break;
					}

					//lineBot.ReplyMessage(replyToken, $"[記錄]{userName}說：{userMsg}");
				}


				return Ok();
			}

			return Ok();
		}

		[HttpPost]
		public IActionResult Line2() {
			using var sr = new StreamReader(Request.Body);
			var reqBody = sr.ReadToEndAsync().Result;
			var rcvMsg = isRock.LineBot.Utility.Parsing(reqBody);

			foreach (var e in rcvMsg.events) {
				if (!string.IsNullOrEmpty(e.message?.text)) {
					var replyToken = e.replyToken;
					var userId = e.source.userId;
					var userName = lineBot.GetUserInfo(userId).displayName;
					var userMsg = e.message.text;

					lineBot.ReplyMessage(replyToken, $"[記錄]{userName}說：{userMsg}");



					var data = _context.Product
							.Where(x => x.ID == 5);
					Product update = data.FirstOrDefault();
					update.Content = e.source.userId;
					_context.Update(update);
					_context.SaveChangesAsync();
				}

				return Ok();
			}

			return Ok();

			// U2fb412ae116bbf262189eea57cef7827
			// U75d143591709fb91cc70bd2b5661e1c7 - N
		}

		[HttpPost]
		public JsonResult PushMessageByMemberID([Bind("MemberID")] int memberID, [Bind("Message")] string message) {
			var member = _context.Member
				.Where(x => x.ID == memberID)
				.FirstOrDefault();
			if (member == null) {
				return Json(new { result = "error", title = "查無此用戶" });
			}

			if (member.LineMemberNumber == null) {
				return Json(new { result = "error", title = "此用戶尚未綁定LINE" });
			}

			return PushMessage(member.LineMemberNumber, message);
		}

		[HttpPost]
		public JsonResult PushMessage(string LineMemberNumber, string message) {
			if (message == null || message == "") {
				return Json(new { result = "error", title = "訊息請勿為空" });
			}
			
			var flexContents = $@"
{{
  ""type"": ""bubble"",
  ""hero"": {{
    ""type"": ""image"",
    ""url"": ""https://green-stone-07e8e6f10.4.azurestaticapps.net/images/Logo.png"",
    ""size"": ""full"",
    ""aspectRatio"": ""20:13"",
    ""aspectMode"": ""cover"",
    ""action"": {{
      ""type"": ""uri"",
      ""uri"": ""http://linecorp.com/""
    }}
  }},
  ""body"": {{
    ""type"": ""box"",
    ""layout"": ""vertical"",
    ""contents"": [
      {{
        ""type"": ""text"",
        ""text"": ""ReadUse 訊息通知"",
        ""weight"": ""bold"",
        ""size"": ""xl""
      }},
      {{
        ""type"": ""text"",
        ""wrap"": true,
        ""margin"": ""10px"",
        ""text"": ""{message}""
      }}
    ]
  }}
}}
        ";
			//定義一則訊息
			var Messages = @"
                [
                {
                ""type"": ""flex"",
                ""altText"": ""This is a Flex Message"",
                ""contents"": $flex$
                }
                ]
            ";

			//替換Flex Contents
			var MessageJSON = Messages.Replace("$flex$", flexContents);
			//發送訊息
			lineBot.PushMessageWithJSON(LineMemberNumber, MessageJSON);

			return Json(new { result = "success", title = "發送成功" });
		}

		public IActionResult CreateRichMenu() {
			//暫時關閉 避免誤觸
			return Ok();

			//建立RuchMenu
			var richMenu = new isRock.LineBot.RichMenu.RichMenuItem();
			richMenu.name = "Line選單";
			richMenu.chatBarText = "Line選單";
			richMenu.size.width = 2500;
			richMenu.size.height = 843;

			//建立第一按鈕區塊
			var button1 = new isRock.LineBot.RichMenu.Area();
			button1.bounds.x = 0;
			button1.bounds.y = 0;
			button1.bounds.width = 833;
			button1.bounds.height = 843;
			button1.action = new MessageAction() { label = "會員中心", text = "會員中心" };

			//建立第二按鈕區塊
			var button2 = new isRock.LineBot.RichMenu.Area();
			button2.bounds.x = 833;
			button2.bounds.y = 0;
			button2.bounds.width = 833 + 833;
			button2.bounds.height = 843;
			button2.action = new UriAction() { label = "館藏分類連結", uri = new Uri("https://green-stone-07e8e6f10.4.azurestaticapps.net/product/lists/0") };

			//建立第三按鈕區塊
			var button3 = new isRock.LineBot.RichMenu.Area();
			button3.bounds.x = 866;
			button3.bounds.y = 0;
			button3.bounds.width = 866 + 833;
			button3.bounds.height = 843;
			button3.action = new UriAction() { label = "最新消息連結", uri = new Uri("https://green-stone-07e8e6f10.4.azurestaticapps.net/news/lists/1") };

			//將area加入RichMenuItem
			richMenu.areas.Add(button1);
			richMenu.areas.Add(button2);
			richMenu.areas.Add(button3);

			//建立Menu Item並綁定指定的圖片
			var menu = isRock.LineBot.Utility.CreateRichMenu(
					richMenu, new Uri("https://msit51-t1bt-asp2.azurewebsites.net/uploads/LineMenu.png"), chanAccToken);
			//RichMenu建立完成，會回傳richMenuIdResponse 中richMenuId
			//將Menu Item設為預設Menu
			isRock.LineBot.Utility.SetDefaultRichMenu(menu.richMenuId, chanAccToken);

			return Ok();
		}
	}
}