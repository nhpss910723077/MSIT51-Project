using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSIT51BT_ASP.Models;
using System;
using System.Diagnostics.Metrics;
using System.Net;
using System.Numerics;
using System.Reflection.Emit;
using System.Reflection;
using Microsoft.CodeAnalysis;
using static System.Net.Mime.MediaTypeNames;
using MSIT51BT_ASP.Libraries;
using isRock.LineBot;
using System.Runtime.Intrinsics.Arm;

namespace MSIT51BT_ASP.Controllers {
    public class MemberController : Controller {

        // 宣告變數_context
        private readonly SqlContext _context;
        private readonly IWebHostEnvironment _env;
        private string uploadPath = "uploads";
        public MemberController(SqlContext context, IWebHostEnvironment env) {
            _context = context;
            _env = env;
        }


        #region Index
        [HttpGet]
        public JsonResult IndexData(int id) { // 傳入登入會員的ID

            var Member = _context.Member
                .Where(m => m.ID == id)
                .FirstOrDefault();

            int FavoriteCount = _context.Favorite
                .Where(f => f.MemberID == id)
                .Count();


            //int ShoppingMoney = _context.ShoppingMoneyRecord
            //    .Where(s => s.MemberID == id)
            //    .Sum(s => s.Money);

            var orderCount = _context.Config
                .Where(c => c.DataCategory == "orderStatus")
                .GroupJoin(_context.OrderForm
                .Where(o => o.MemberID == Member.ID),
                    c => c.DataValue,
                    o => o.Status,
                    (c, o) => new {
                        DataCategory = c.DataName,
                        StatusCount = o.Count()
                    });


            //return Json(new {  });
            return Json(new {
                //優惠券數量沒有做
                Name = Member.Name,
                LineMemberNumber = Member.LineMemberNumber,
                FavoriteCount = FavoriteCount,
                ShoppingMoneyRecord = Member.ShoppingMoney,
                orderCount = orderCount,

            });
        }

        #endregion


        #region DataUpdate
        [HttpGet]
        public JsonResult DataUpdate(int id) { // 傳入登入會員的ID

            var member = _context.Member
                        .Where(m => m.ID == id);

            //return Json(new {  });
            return Json(member.FirstOrDefault());
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<JsonResult> EditDataUpdate(int id, [Bind("ID,Name,NickName,Phone,ZipCode,County,District,Address,Gender,Birthday")] Member m) {
            Member? update = _context.Member
                        .Where(x => x.ID == id)
                        .FirstOrDefault();

            if (update == null) {
                return Json(new { result = "info", title = "查無此項目" });
            }

            // 這裡放要修改的欄位和值
            update.ID = m.ID;
            update.Name = m.Name;
            update.NickName = m.NickName;
            update.Phone = m.Phone;
            update.Zipcode = m.Zipcode;
            update.County = m.County;
            update.District = m.District;
            update.Address = m.Address;
            update.Gender = m.Gender;
            update.Birthday = m.Birthday;

            try {
                _context.Update(update);
                await _context.SaveChangesAsync();

                return Json(new { result = "success", title = "更新成功" });
            }
            catch (DbUpdateConcurrencyException) {
                return Json(new { result = "info", title = "更新失敗" });
            }
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<JsonResult> PasswordUpdate(int id) {
            Member? update = _context.Member
                        .Where(x => x.ID == id)
                        .FirstOrDefault();
            if (update == null) {
                return Json(new { result = "error", title = "查無此人" });
            }
            var userEmail = update.Account;
            var originPassword = HttpContext.Request.Form["originalPassword"];
            var newPassword = HttpContext.Request.Form["NewPassword"];

            // 查詢舊密碼
            string FinalPwd = Libraries.MyHelper.SecrectPwd(userEmail, originPassword);  //FinalPwd為加密最終結果

            if (update.Password != FinalPwd) {
                return Json(new { result = "info", title = "舊密碼輸入錯誤" });
            }

            // 更改新密碼
            string NewFinalPwd = Libraries.MyHelper.SecrectPwd(userEmail, newPassword);
            update.Password = NewFinalPwd;


            try {
                _context.Update(update);
                await _context.SaveChangesAsync();

                return Json(new { result = "success", title = "更新成功" });
            }
            catch (DbUpdateConcurrencyException) {
                return Json(new { result = "info", title = "更新失敗" });
            }
        }

        #endregion


        #region Favorite
        [HttpGet]
        public JsonResult FavoriteList(int id) { // 傳入登入會員的ID

            var FavoriteList = _context.Favorite
                .Join(_context.Product,
                f => f.ProductID,
                p => p.ID,
                (f, p) => new {
                    ID = f.ID,
                    MemberID = f.MemberID,
                    Img1 = p.Img1 != null ? MyHelper.GetFilePath(HttpContext, p.Img1) : "",
                    Name = p.Name,
                    ListPrice = p.ListPrice,
                    SalePrice = p.SalePrice,
                    pID = p.ID
                })
                .Where(f => f.MemberID == id);

            //return Json(new {  });
            return Json(FavoriteList);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<JsonResult> FavoriteDelete(int id) {
            // 傳入的id是Favorite的ID

            //Favorite? deleteData = _context.Favorite
            //             .Where(f => f.ID == id)
            //             .FirstOrDefault();

            var Favorite = await _context.Favorite.FindAsync(id);
            if (Favorite == null) {
                return Json(new { result = "info", title = "查無此項目" });
            }

            _context.Favorite.Remove(Favorite);
            await _context.SaveChangesAsync();
            return Json(new { result = "success", title = "刪除成功" });
        }


        #endregion

        #region Bookcase
        [HttpGet]
        public JsonResult Bookcase(int id) {
            var bookcaseList = _context.Bookcase
                .Join(_context.Product,
                    b => b.ProductID,
                    p => p.ID,
                    (b, p) => new {
                        ID = b.ID,
                        MemberID = b.MemberID,
                        ProductID = b.ProductID,
                        //Img1 = x.Img1 != null ? MyHelper.GetFilePath(HttpContext, x.Img1) : "",
                        Img1 = p.Img1 != null ? MyHelper.GetFilePath(HttpContext, p.Img1) : "",
                        Name = p.Name,
                        Author = p.Author,
                        ISBN10 = p.ISBN10,
                        ISBN13 = p.ISBN13,
                        Publisher = p.Publisher,
                        ProductCategory = p.ProductCategory.Name,
                        Score = b.Score,
                        ReviewTitle = b.ReviewTitle,
                        Review = b.Review,
                        UpdateTime = b.UpdateTime,
                    })
                .OrderByDescending(b => b.UpdateTime)
                .Where(b => b.MemberID == id);
            return Json(bookcaseList);
        }

        [HttpPost]
        public JsonResult ISBNSearch(int id) {

            string? info = HttpContext.Request.Form["ISBNInput"];

			var ISBNResult = _context.Product
				.Join(_context.ProductCategory,
				p => p.ProductCategoryID,
				pc => pc.ID,
				(p, pc) => new {
                    ID = p.ID,
                    ISBN10 = p.ISBN10,
                    ISBN13 = p.ISBN13,
					Name = p.Name,
					SalePrice = p.SalePrice,
					Author = p.Author,
					Publisher = p.Publisher,
					Img1 = p.Img1 != null ? MyHelper.GetFilePath(HttpContext, p.Img1) : "",
					ProductCategory = pc.Name
				}).Where(p => p.ISBN10 == info || p.ISBN13 == info)
				
				.FirstOrDefault();
			
			if (ISBNResult == null)
			{
				return Json(new { result = "info", title = "查無此項目" });
			}

            Bookcase? existedBook = _context.Bookcase
                        .Where(x => x.MemberID == id && x.ProductID == ISBNResult.ID)
                        .FirstOrDefault();

            
			if (existedBook != null) {
				return Json(new { result = "info", title = "本書籍已存在於書櫃中" });
			}
			else {
				return Json(ISBNResult);
			}

		}

		[HttpPost]
		//[ValidateAntiForgeryToken]
		public async Task<JsonResult> BookInsert(int id ,[Bind("ProductID,ReviewTitle,Review,Score")] Bookcase book)
		{
			// 其他預設值寫在這邊
			// news.Sort = 0; // 數字預設值是0 所以可以不用
			book.Enable = true; //這個基本上預設都是填true
			book.MemberID = id;

			if (ModelState.IsValid) {

				_context.Add(book);
				await _context.SaveChangesAsync();

				return Json(new { result = "success", title = "新增成功" });
			}

			var ModelStateErrors = ModelState.Where(x => x.Value.Errors.Count > 0)
			.ToDictionary(k => k.Key, k => k.Value.Errors.Select(e => e.ErrorMessage).ToArray());

			return Json(new { result = "error", title = "發生錯誤", data = ModelStateErrors });
		}


		[HttpPost]
		//[ValidateAntiForgeryToken]
		public async Task<JsonResult> BookEdit([Bind("ID,MemberID,ProductID,ReviewTitle,Review,Score")] Bookcase book) {
			Bookcase? data = _context.Bookcase
						.Where(x => x.ID == book.ID)
						.FirstOrDefault();

			if (data == null) {
				return Json(new { result = "info", title = "查無此項目" });
			}

			// 這裡放要修改的欄位和值
			data.MemberID = book.MemberID;
			data.ProductID = book.ProductID;
			data.ReviewTitle = book.ReviewTitle;
			data.Review = book.Review;
			data.Score = book.Score;

			if (ModelState.IsValid) {
				try {
					_context.Update(data);
					await _context.SaveChangesAsync();

					return Json(new { result = "success", title = "更新成功" });
				}
				catch (DbUpdateConcurrencyException) {
					return Json(new { result = "info", title = "更新失敗" });
				}
			}

			var ModelStateErrors = ModelState.Where(x => x.Value.Errors.Count > 0)
			.ToDictionary(k => k.Key, k => k.Value.Errors.Select(e => e.ErrorMessage).ToArray());

			return Json(new { result = "error", title = "發生錯誤", data = ModelStateErrors });
		}



		#endregion

		#region Message
		[HttpGet]
		public JsonResult MessageList(int id) {
			List<MemberMessage>? MessageList = _context.MemberMessage
				.Where(m => m.MemberID == id).ToList();

			if (MessageList == null) {
				return Json(new { result = "info", title = "目前無訊息" });
			}

			return Json(MessageList);

		}
		#endregion

		#region order
		[HttpGet]
		public JsonResult orderList(int id) {
			var orderList = _context.OrderForm
				.Join(_context.Payment,
				of => of.PaymentType,
				p => p.ID,
				(of, p) => new {
					PaymentName = p.Name,
					ID = of.ID, // 訂單ID
					Number = of.Number, // 訂單編號
					MemberID = of.MemberID, // 會員ID
					CreateTime = of.CreateTime, // 付款時間=>訂單日期
					ShippingFee = of.ShippingFee,
					CVSStoreName = of.CVSStoreName,
					SubTotal = of.SubTotal,
					Total = of.Total,
					ShippingType = of.ShippingType,
					Status = of.Status,

				})
				.Join(_context.Shipping,
				of => of.ShippingType,
				s => s.ID,
				(of, s) => new {
					PaymentName = of.PaymentName,
					ID = of.ID, // 訂單ID
					Number = of.Number, // 訂單編號
					MemberID = of.MemberID, // 會員ID
					CreateTime = of.CreateTime, // 付款時間=>訂單日期
					ShippingFee = of.ShippingFee,
					CVSStoreName = of.CVSStoreName,
					SubTotal = of.SubTotal,
					Total = of.Total,
					ShippingType = s.Name,
					Status = of.Status,
				})
				.Join(_context.Config,
				of => of.Status,
				c => c.DataValue,
				(of, c) => new {
					ID = of.ID, // 訂單ID
					Number = of.Number, // 訂單編號
					MemberID = of.MemberID, // 會員ID
					CreateTime = of.CreateTime, // 付款時間=>訂單日期
					DataCategory = c.DataCategory,
					ShippingFee = of.ShippingFee,
					CVSStoreName = of.CVSStoreName,
					SubTotal = of.SubTotal,
					Total = of.Total,
					Status = c.DataName,
					PaymentName = of.PaymentName,
					ShippingType = of.ShippingType,
				})

				.Where(o => o.DataCategory == "OrderStatus" && o.MemberID == id)
				.OrderByDescending(o => o.CreateTime)
				.Select(o => new {
					ID = o.ID, // 訂單ID
					Number = o.Number, // 訂單編號
					MemberID = o.MemberID, // 會員ID
					CreateTime = o.CreateTime, // 付款時間=>訂單日期
					ShippingFee = o.ShippingFee,
					CVSStoreName = o.CVSStoreName,
					SubTotal = o.SubTotal,
					Total = o.Total,
					Status = o.Status,
					PaymentName = o.PaymentName,
					ShippingType = o.ShippingType,
					OrderDetail = _context.OrderDetail
									.Where(od => od.OrderFormID == o.ID)
									.Join(_context.Product,
											o => o.ProductID,
											p => p.ID,
											(o, p) => new {
												ID = o.ID,
												OrderFormID = o.OrderFormID,
												ProductID = o.ProductID, // 訂購商品
												ProductName = p.Name,
												//Img1 = p.Img1 != null ? MyHelper.GetFilePath(HttpContext, p.Img1) : "",
												Img1 = p.Img1 != null ? MyHelper.GetFilePath(HttpContext, p.Img1) : "",
												Quantity = o.Quantity, // 數量
												SalePrice = o.SalePrice, // 單價
											})
									.GroupBy(od => od.ProductID) // 按 ProductID 分组
			.Select(group => group.First()) // 选择每个分组的第一个元素
			.ToList()



				}).ToList();

			var orderReturnList = _context.OrderForm
				.Join(_context.OrderReturn,
				of => of.ID,
				or => or.OrderFormID,
				(of, or) => new {
					MemberID = of.MemberID,
					ID = of.ID,
					ReturnProduct = or.ReturnProduct,
				}
				).Where(o => o.MemberID == id);


            if (orderList == null) {
				return Json(new { result = "info", title = "目前無訂單" });
			}
			return Json(new { orderList = orderList, orderReturnList = orderReturnList });
		}

		[HttpPost]
		//[ValidateAntiForgeryToken]
		public async Task<JsonResult> orderReturn([Bind("OrderFormID,ReturnProduct,Reason")] OrderReturn oderReturn) {
			var test = HttpContext.Request.Form["Reason"];
            //return Json(new { result = "success", title = "更新成功", data= oderReturn, test = test });
            OrderForm? data = _context.OrderForm
						.Where(x => x.ID == oderReturn.OrderFormID)
						.FirstOrDefault();

			if (data == null) {
				return Json(new { result = "info", title = "查無此項目" });
			}

			// 這裡放要修改的欄位和值
			data.Status = 4; // 訂單退貨
			oderReturn.Enable = true;

			if (ModelState.IsValid) {
				try {

					_context.Update(data);
					_context.Add(oderReturn);
					await _context.SaveChangesAsync();

					return Json(new { result = "success", title = "更新成功" });
				}
				catch (DbUpdateConcurrencyException) {
					return Json(new { result = "info", title = "更新失敗" });
				}
			}

			var ModelStateErrors = ModelState.Where(x => x.Value.Errors.Count > 0)
			.ToDictionary(k => k.Key, k => k.Value.Errors.Select(e => e.ErrorMessage).ToArray());

			return Json(new { result = "error", title = "發生錯誤", data = ModelStateErrors });
		}
		[HttpPost]
		//[ValidateAntiForgeryToken]
		public async Task<JsonResult> orderCancel([Bind("OrderFormID,Reason")] OrderCancel orderCancel) {
			//var test = HttpContext.Request.Form["Reason"];
			//return Json(new { result = "success", title = "更新成功", data= oderReturn, test = test });
			OrderForm? data = _context.OrderForm
						.Where(x => x.ID == orderCancel.OrderFormID)
						.FirstOrDefault();

			if (data == null) {
				return Json(new { result = "info", title = "查無此項目" });
			}

			// 這裡放要修改的欄位和值
			data.Status = 3; // 訂單取消
			orderCancel.Enable = true;

			if (ModelState.IsValid) {
				try {

					_context.Update(data);
					_context.Add(orderCancel);
					await _context.SaveChangesAsync();

					return Json(new { result = "success", title = "更新成功" });
				}
				catch (DbUpdateConcurrencyException) {
					return Json(new { result = "info", title = "更新失敗" });
				}
			}

			var ModelStateErrors = ModelState.Where(x => x.Value.Errors.Count > 0)
			.ToDictionary(k => k.Key, k => k.Value.Errors.Select(e => e.ErrorMessage).ToArray());

			return Json(new { result = "error", title = "發生錯誤", data = ModelStateErrors });
		}

		#endregion

		#region usedBook
		[HttpGet]
		public JsonResult UsedBookList(int id)
		{
			var usedBookList = _context.UsedSale
				.Join(_context.Product,
				u => u.ProductID,
				p => p.ID,
				(u, p) => new {
					ID = u.ID,
					MemberID = u.MemberID,
					ProductID = u.ProductID,
					ISBN10 = p.ISBN10,
					ISBN13 = p.ISBN13,
					ProductName = p.Name,
					SalePrice = u.SalePrice,
					WithdrawType = u.WithdrawType,
					RemitAccount = u.RemitAccount,
					BookStatus = u.BookStatus,
					Img1 = u.Img1 != null ? MyHelper.GetFilePath(HttpContext, u.Img1) : "",
					Img2 = u.Img2 != null ? MyHelper.GetFilePath(HttpContext, u.Img2) : "",
					Img3 = u.Img3 != null ? MyHelper.GetFilePath(HttpContext, u.Img3) : "",

					VerifyStatus = u.VerifyStatus,
					VerifyDateTime = u.VerifyDateTime,
					Sold = u.Sold,
					Enable = u.Enable,
					UpdateTime = u.UpdateTime,
					CreateTime = u.CreateTime
				})
				.Where(b => b.MemberID == id)
				.OrderByDescending(b => b.CreateTime);

			if (usedBookList == null) {
				return Json(new { result = "info", title = "目前尚無上架二手書籍" });
			}

			return Json(usedBookList);

		}

		[HttpPost]
		public async Task<JsonResult> UsedBookUnlist() {

			UsedSale? data = _context.UsedSale
						.Where(x => x.ID.ToString() == HttpContext.Request.Form["ID"].ToString())
						.FirstOrDefault();

			if (data == null) {
				return Json(new { result = "info", title = "查無此項目" });
			}

			// 這裡放要修改的欄位和值
			data.VerifyStatus = 3; // 訂單取消


			if (ModelState.IsValid) {
				try {

					_context.Update(data);
					await _context.SaveChangesAsync();

					return Json(new { result = "success", title = "商品已下架" });
				}
				catch (DbUpdateConcurrencyException) {
					return Json(new { result = "info", title = "更新失敗" });
				}
			}

			var ModelStateErrors = ModelState.Where(x => x.Value.Errors.Count > 0)
			.ToDictionary(k => k.Key, k => k.Value.Errors.Select(e => e.ErrorMessage).ToArray());

			return Json(new { result = "error", title = "發生錯誤", data = ModelStateErrors });
		}


		[HttpGet]
		public JsonResult Step1BookSearch(string id) {
			Product? ISBNResult = _context.Product
				.Where(p => p.ISBN10 == id || p.ISBN13 == id)
				.FirstOrDefault();

			if (ISBNResult == null) {

				return Json(new { result = "info", title = "查無此項目" });

			}
			else {

				return Json(ISBNResult);
			}

		}

		[HttpPost]
		//[ValidateAntiForgeryToken]
		public async Task<JsonResult> UsedSaleInsert([Bind("MemberID,ProductID,ProductName,SalePrice,WithdrawType,BookStatus,Imgs,VerifyStatus,VerifyStatus")] UsedSale usedSale) {

			usedSale.Sold = false;
			usedSale.Enable = true;


            if (ModelState.IsValid) {
                // 檔案上傳
                try {
                    string[] relativePathList = { "", "", "" };

                    if (Request.Form.Files["Imgs"] != null) {

                        for (int i = 0; i < Request.Form.Files.Count; i++) {
                            IFormFile file = Request.Form.Files[i];

							while (true) {
								string fileName = MyHelper.GetRandomChar(30) + Path.GetExtension(file.FileName);
								string relativePath = Path.Combine(uploadPath, fileName);
								string filePath = Path.Combine(_env.WebRootPath, relativePath);

								if (!System.IO.File.Exists(filePath)) {
									using Stream fileStream = System.IO.File.Create(filePath);
									file.CopyTo(fileStream);
									fileStream.Close();

                                    relativePathList[i] = relativePath;
                                    break;
                                }
                            }
                        }
                    }

                    usedSale.Img1 = relativePathList[0];
                    usedSale.Img2 = relativePathList[1];
					usedSale.Img3 = relativePathList[2];

				}
                catch (Exception e) {
                    return Json(new { result = "info", title = "檔案上傳失敗" });
                }

                _context.Add(usedSale);
                await _context.SaveChangesAsync();

                return Json(new { result = "success", title = "送出成功", text = "將於收件審核後上架", ID = usedSale.ID });
            }

            var ModelStateErrors = ModelState.Where(x => x.Value.Errors.Count > 0)
            .ToDictionary(k => k.Key, k => k.Value.Errors.Select(e => e.ErrorMessage).ToArray());

            return Json(new { result = "error", title = "送出失敗，請檢查欄位", data = ModelStateErrors });
        }
       
		#endregion

		#region usedSeek
		[HttpPost]
		public async Task<JsonResult> UsedSeek([Bind("MemberID, ProductID, SeekPrice")] UsedSeek usedSeek) {
			usedSeek.Enable = true;

			if (ModelState.IsValid) {
				_context.Add(usedSeek);
				await _context.SaveChangesAsync();

				var bookcase = _context.Bookcase
						.Join(_context.Member,
							bookcase => bookcase.MemberID,
							member => member.ID,
							(bookcase, member) => new { BookcaseItem = bookcase, MemberItem = member })
						.Join(_context.Product,
							bookcase => bookcase.BookcaseItem.ProductID,
							product => product.ID,
							(bookcase, product) => new { BookcaseItem = bookcase.BookcaseItem, MemberItem = bookcase.MemberItem, ProductItem = product })
						.Where(x => x.BookcaseItem.ProductID == usedSeek.ProductID)
						.Where(x => x.MemberItem.LineMemberNumber != null)
						.Select(x => new {
							ProductName = x.ProductItem.Name,
							MemberName = x.MemberItem.Name,
							MemberID = x.BookcaseItem.MemberID,
							LineMemberNumber = x.MemberItem.LineMemberNumber,
						});

				foreach (var item in bookcase) {
					string message = $"最近有人徵求了您書櫃內的 {item.ProductName} 請問您有意願販售這本書嗎?";

					MemberMessage memberMessage = new MemberMessage() {
						MemberID = item.MemberID,
						Content = message,
						Sort = 0,
						Enable = true,
					};

					_context.Add(memberMessage);
					_context.SaveChangesAsync();

					var instance = new LineController(_context); // Replace YourClass with the actual class name
					instance.PushMessage(item.LineMemberNumber, message);
				}

				return Json(new { result = "success", title = "送出成功" });
			}

			var ModelStateErrors = ModelState.Where(x => x.Value.Errors.Count > 0)
			.ToDictionary(k => k.Key, k => k.Value.Errors.Select(e => e.ErrorMessage).ToArray());

			return Json(new { result = "error", title = "發生錯誤", data = ModelStateErrors });
		}
		#endregion



        #region Menu
        [HttpGet]
        public JsonResult MemberMenu() {


            var menuItems = new[]
        {
            new { title = "我的帳戶", link = "/member/index" },
            new { title = "訂單查詢", link = "/member/order" },
            new { title = "收藏清單", link = "/member/favorite" },
            //new { title = "優惠券", link = "./member_coupon.html" },
            new { title = "我的書櫃", link = "/member/bookcase" },
            new { title = "二手書販售", link = "/member/usedBookStep3" },
            new { title = "二手書徵求", link = "/member/usedSeek" },
            new { title = "訊息通知", link = "/member/message" },
            new { title = "會員資料修改", link = "/member/update" },
            new { title = "密碼修改", link = "/member/changePassword" },
            new { title = "登出", link = "/member/Logout" }
        };

            return Json(menuItems);
        }
    }
}

#endregion

