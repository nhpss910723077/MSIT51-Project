using isRock.LineBot;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSIT51BT_ASP.Libraries;
using MSIT51BT_ASP.Models;
using System.Security.Cryptography;
using System.Text;
using System.Web;


namespace MSIT51BT_ASP.Controllers {
	public class CartController : Controller {
		private readonly SqlContext _context;

		public CartController(SqlContext context) {
			_context = context;

		}
		#region shoppingCart_step1
		// 讀取購物車資料
		public JsonResult ReadCart(int MemberID) {
			var data = _context.Cart
						.Where(x => x.MemberID == MemberID)
						.Select(x => x.ID);
			return Json(data);
		}
		// 讀取購物車資料_Normal
		public JsonResult CartNormal(int MemberID) {
			var data = _context.Cart
						.Join(_context.Product, x => x.ProductID, y => y.ID, (x, y) => new { x, y })
						.Where(z => z.x.MemberID == MemberID && z.x.Type == "Normal")
						.Select(z => new { z.x.ID, z.x.Type, z.x.ProductID, z.x.UsedID, Img1 = z.y.Img1 != null ? MyHelper.GetFilePath(HttpContext, z.y.Img1) : "", z.y.Stock, z.y.Name, z.y.SalePrice, z.x.Quantity });
			return Json(data);
		}

		// 讀取購物車資料_Customer
		public JsonResult CartCustomer(int MemberID) {
			var data = _context.Cart
						.Join(_context.Product, a => a.ProductID, b => b.ID, (a, b) => new { a, b })
						.Join(_context.UsedSale, c => c.a.UsedID, d => d.ID, (c, d) => new { c, d })
						.Where(e => e.c.a.MemberID == MemberID && e.c.a.Type == "Customer")
						.Select(e => new { e.c.a.ID, e.c.a.Type, e.c.a.ProductID, e.c.a.UsedID, e.c.b.Name, Img1 = e.d.Img1 != null ? MyHelper.GetFilePath(HttpContext, e.d.Img1) : "", e.d.SalePrice, e.c.a.Quantity });
			return Json(data);
		}
		// 讀取最愛
		public JsonResult Favorite(int MemberID) {
			var data = _context.Favorite
						.Where(x => x.MemberID == MemberID)
						.Select(x => new { x.ID, x.ProductID });
			return Json(data);
		}
		// 加入最愛
		[HttpPost]
		public async Task<JsonResult> AddFavorite([Bind("MemberID,ProductID")] Favorite favorite) {
			// 判斷是否重複加入
			var data = _context.Favorite
						.Where(x => x.MemberID == favorite.MemberID && x.ProductID == favorite.ProductID)
						.Select(x => x.ID);
			if (data.ToList().Count != 0) {
				return Json(new { result = "success", title = "已經在收藏清單囉！" });
			}
			if (ModelState.IsValid) {
				_context.Add(favorite);
				await _context.SaveChangesAsync();

				return Json(new { result = "success", title = "加入收藏！" });
			}

			var ModelStateErrors = ModelState.Where(x => x.Value.Errors.Count > 0)
			.ToDictionary(k => k.Key, k => k.Value.Errors.Select(e => e.ErrorMessage).ToArray());

			return Json(new { result = "error", title = "發生錯誤", data = ModelStateErrors });
		}
		// 移除最愛
		[HttpPost]
		public async Task<JsonResult> DeleteFavorite([Bind("MemberID,ProductID")] Favorite deleteItem) {
			// 3種接收傳送進來的資料的寫法
			// 寫法1 使用[Bind("實體Model的欄位")] 實體Model類別 自訂義名稱
			if (_context.Favorite == null) {
				return Json(new { result = "info", title = "查無此項目" });
			}
			var data = _context.Favorite
						.Where(x => x.MemberID == deleteItem.MemberID && x.ProductID == deleteItem.ProductID)
						.First();


			if (data == null) {
				return Json(new { result = "info", title = "查無此項目" });
			}

			_context.Favorite.Remove(data);
			await _context.SaveChangesAsync();
			return Json(new { result = "success", title = "刪除成功", });
		}
		// 加入購物車
		[HttpPost]
		public async Task<JsonResult> AddCart([Bind("Type,MemberID,ProductID,UsedID")] Cart cart) {
			// 判斷是否重複加入
			var data = _context.Cart
						.Where(x => x.Type == cart.Type && x.MemberID == cart.MemberID && x.ProductID == cart.ProductID && x.UsedID == cart.UsedID)
						.Select(x => x.ID);
			if (data.ToList().Count != 0) {
				return Json(new { result = "success", title = "已經在購物車囉！" });
			}


			cart.Quantity = 1; // 預設加入購物車數量都為1
			if (ModelState.IsValid) {
				_context.Add(cart);
				await _context.SaveChangesAsync();

				return Json(new { result = "success", title = "加入購物車" });
			}

			var ModelStateErrors = ModelState.Where(x => x.Value.Errors.Count > 0)
			.ToDictionary(k => k.Key, k => k.Value.Errors.Select(e => e.ErrorMessage).ToArray());

			return Json(new { result = "error", title = "發生錯誤", data = ModelStateErrors });
		}
		// 更新購物車商品數量
		[HttpPost]
		public async Task<JsonResult> CartUpdate(int ID, int Quantity) {

			var cart = await _context.Cart.FindAsync(ID);

			if (cart == null) {
				return Json(new { result = "info", title = "查無此項目" });
			}

			if (ModelState.IsValid) {
				try {
					// 寫法2 自己定一個傳送進來的參數(此處為int Quantity)，需要自行定義好型態
					cart.Quantity = Quantity;

					await _context.SaveChangesAsync();

					return Json(new { result = "success", title = "更新成功" });
				}
				catch (DbUpdateConcurrencyException) {
					return Json(new { result = "info", title = "查無此項目" });
				}
			}

			var ModelStateErrors = ModelState.Where(x => x.Value.Errors.Count > 0)
				.ToDictionary(k => k.Key, k => k.Value.Errors.Select(e => e.ErrorMessage).ToArray());

			return Json(new { result = "error", title = "發生錯誤", data = ModelStateErrors });
		}
		// 刪除購物車商品
		[HttpPost]
		public async Task<JsonResult> CartDelete([Bind("Type,MemberID,ProductID")] Cart cart) {
			if (_context.Cart == null) {
				return Json(new { result = "info", title = "資料庫為空" });
			}
			var data = _context.Cart
					  .Where(x => x.Type == cart.Type && x.MemberID == cart.MemberID && x.ProductID == cart.ProductID)
					  .First();
			if (data == null) {
				return Json(new { result = "info", title = "查無此項目" });
			}

			_context.Cart.Remove(data);
			await _context.SaveChangesAsync();
			return Json(new { result = "success", title = "刪除成功" });
		}

		#endregion
		// 讀取會員資料
		public JsonResult Member(int MemberID) {
			var data = _context.Member
						.Where(x => x.ID == MemberID)
						.Select(x => new { x.Name, x.Account, x.Phone, x.County, x.District, x.Zipcode, x.Address, x.ShoppingMoney });
			return Json(data);
		}


		// 自動生成訂單編號
		public string GenerateOrderNumber() {
			int lastOrderNumber = 0;

			if (_context.OrderForm != null) {
				var data = _context.OrderForm
				.OrderBy(x => x.ID)
				.Last();
				lastOrderNumber = data.ID;
			}
			lastOrderNumber++;
			return "ORD" + lastOrderNumber.ToString().PadLeft(7, '0'); // 格式化編號
		}
		////新增訂單 用Bind的寫法
		[HttpPost]
		public async Task<JsonResult> AddOrderForm([Bind("Number,ReceiveName,ReceiveEmail,ReceivePhone,ReceiveCounty,ReceiveDistrict," +
			"ReceiveZipcode,ReceiveAddress,Remark,SubTotal,ShippingType,PaymentType,ShippingFee,Total")] OrderForm order, int MemberID) {

			// 
			//if (ModelState.ContainsKey("Number")) { 
			//    ModelState["Number"]?.Errors.Clear(); 
			//}

			if (ModelState.IsValid) {
				order.Status = 0;
				order.PaymentStatus = false;
				order.MemberID = MemberID;
				order.Enable = true;
				order.Number = GenerateOrderNumber();


				_context.OrderForm.Add(order);
				await _context.SaveChangesAsync();

				return Json(new { result = "success", title = "送出成功" });
			}

			var ModelStateErrors = ModelState.Where(x => x.Value.Errors.Count > 0)
			.ToDictionary(k => k.Key, k => k.Value.Errors.Select(e => e.ErrorMessage).ToArray());

			return Json(new { result = "error", title = "發生錯誤", data = ModelStateErrors });
		}


		// 新增訂單 不用Bind的寫法
		//[HttpPost]
		//public async Task<JsonResult> AddOrderForm() {
		//	int MemberID = int.Parse(HttpContext.Request.Form["MemberID"]!);
		//	// 寫法3 使用HttpContext.Request.Form["前端傳送來的資料名稱"]，但此方法傳進來是字串，故需要自行轉換資料型態
		//	OrderForm order = new OrderForm();
		//	order.ReceiveName = HttpContext.Request.Form["ReceiveName"]!;
		//	order.ReceiveEmail = HttpContext.Request.Form["ReceiveEmail"]!;
		//	order.ReceivePhone = HttpContext.Request.Form["ReceivePhone"]!;
		//	order.ReceiveCounty = HttpContext.Request.Form["ReceiveCounty"]!;
		//	order.ReceiveDistrict = HttpContext.Request.Form["ReceiveDistrict"]!;
		//	if (HttpContext.Request.Form["ReceiveZipcode"]!.Any()) {
		//		order.ReceiveZipcode = null;
		//	}
		//	else {
		//		order.ReceiveZipcode = int.Parse(HttpContext.Request.Form["ReceiveZipcode"]!);
		//	}
		//	order.ReceiveAddress = HttpContext.Request.Form["ReceiveAddress"]!;
		//	order.Remark = HttpContext.Request.Form["Remark"]!;
		//	order.SubTotal = int.Parse(HttpContext.Request.Form["SubTotal"]!);
		//	order.ShippingType = int.Parse(HttpContext.Request.Form["ShippingType"]!);
		//	order.PaymentType = int.Parse(HttpContext.Request.Form["PaymentType"]!);
		//	order.ShippingFee = int.Parse(HttpContext.Request.Form["ShippingFee"]!);
		//	order.Total = int.Parse(HttpContext.Request.Form["Total"]!);
		//	order.Status = 0;
		//	order.Enable = true;
		//	order.PaymentStatus = false;
		//	order.MemberID = MemberID;
		//	order.Number = GenerateOrderNumber();



		//	if (ModelState.IsValid) {
		//		_context.OrderForm.Add(order);
		//		await _context.SaveChangesAsync();

		//		return Json(new { result = "success", title = "送出成功" });
		//	}

		//	var ModelStateErrors = ModelState.Where(x => x.Value.Errors.Count > 0)
		//	.ToDictionary(k => k.Key, k => k.Value.Errors.Select(e => e.ErrorMessage).ToArray());

		//	return Json(new { result = "error", title = "發生錯誤", data = ModelStateErrors });
		//}


		// 新增訂單名細
		[HttpPost]
		public async Task<JsonResult> AddOrderDetail([Bind("ProductID,ProductName,Quantity,SalePrice,Type,UsedID")] OrderDetail order, int MemberID) {


			var data = _context.OrderForm
					   .Where(x => x.MemberID == MemberID)
					   .OrderBy(x => x.ID)
					   .Last();

			if (ModelState.IsValid) {
				order.OrderFormID = data.ID;
				_context.OrderDetail.Add(order);
				await _context.SaveChangesAsync();

				return Json(new { result = "success", title = "送出成功" });
			}

			var ModelStateErrors = ModelState.Where(x => x.Value.Errors.Count > 0)
			.ToDictionary(k => k.Key, k => k.Value.Errors.Select(e => e.ErrorMessage).ToArray());

			return Json(new { result = "error", title = "發生錯誤", data = ModelStateErrors });
		}



		// 綠界檢查碼
		private string GetCheckMacValue(Dictionary<string, string> order) {
			var param = order.Keys.OrderBy(x => x).Select(key => key + "=" + order[key]).ToList();
			var checkValue = string.Join("&", param);
			//測試用的 HashKey
			var hashKey = "5294y06JbISpM5x9";
			//測試用的 HashIV
			var HashIV = "v77hoKGq4kWxNNIS";
			checkValue = $"HashKey={hashKey}" + "&" + checkValue + $"&HashIV={HashIV}";
			checkValue = HttpUtility.UrlEncode(checkValue).ToLower();
			checkValue = GetSHA256(checkValue);
			return checkValue.ToUpper();
		}
		private string GetSHA256(string value) {
			var result = new StringBuilder();
			var sha256 = SHA256.Create();
			var bts = Encoding.UTF8.GetBytes(value);
			var hash = sha256.ComputeHash(bts);
			for (int i = 0; i < hash.Length; i++) {
				result.Append(hash[i].ToString("X2"));
			}
			return result.ToString();
		}
		private string GetCheckMacValueMD5(Dictionary<string, string> order) {
			var param = order.Keys.OrderBy(x => x).Select(key => key + "=" + order[key]).ToList();
			var checkValue = string.Join("&", param);
			//測試用的 HashKey
			var hashKey = "5294y06JbISpM5x9";
			//測試用的 HashIV
			var HashIV = "v77hoKGq4kWxNNIS";
			checkValue = $"HashKey={hashKey}" + "&" + checkValue + $"&HashIV={HashIV}";
			checkValue = HttpUtility.UrlEncode(checkValue).ToLower();
			checkValue = GetMD5(checkValue);
			return checkValue.ToUpper();
		}
		private string GetMD5(string value) {
			using (MD5 md5 = MD5.Create()) {
				var result = new StringBuilder();
				byte[] dataBytes = Encoding.UTF8.GetBytes(value);
				byte[] hashBytes = md5.ComputeHash(dataBytes);
				for (int i = 0; i < hashBytes.Length; i++) {
					result.Append(hashBytes[i].ToString("x2"));
				}
				return result.ToString();
			}
		}
		// 發送參數到電子地圖
		[HttpPost]
		public Dictionary<string, string> AddMap(string LogisticsSubType) {


			var order = new Dictionary<string, string>
			{
                //綠界需要的參數
				{ "MerchantID",  "2000132"},
				{ "LogisticsType", "CVS"},
				{ "IsCollection",  "N"},
				{ "ServerReplyURL",  "https://localhost:7038/cart/MapReturn"},
			};
			switch (LogisticsSubType) {
				case "萊爾富":
					order["LogisticsSubType"] = "HILIFE";
					break;
				case "全家":
					order["LogisticsSubType"] = "FAMI";
					break;
				case "統一超商":
					order["LogisticsSubType"] = "UNIMART";
					break;

			}
			return order;

		}
		// 電子地圖回傳
		[HttpPost]
		public IActionResult MapReturn() {
			var data = Request.Form;
			var x = new {
				CVSID = data["CVSStoreID"],
				CVSStoreName = data["CVSStoreName"],
				CVSStoreAddress = data["CVSAddress"]
			};
			// 沒有實際做出功能，只有導回原本頁面
			return Redirect("http://localhost:8080/cart/Step2");
		}

		// 發送金流訂單到綠界
		[HttpPost]
		public async Task<Dictionary<string, string>> AddEcpayOrders(int PaymentType, int ShippingType, int MemberID, int UseShoppingMoney) {
			// 得到orderform
			var data1 = _context.OrderForm
					   .Where(x => x.MemberID == MemberID)
					   .OrderBy(x => x.ID)
					   .Last();
			// 得到order的商品
			var data2 = _context.OrderDetail
					   .Where(x => x.OrderFormID == data1.ID)
					   .OrderBy(x => x.ID)
					   .Select(x => new { Name = x.ProductName, Price = x.SalePrice, x.Quantity, })
					   .ToList();

			string orderItem = "";
			foreach (var item in data2) {
				orderItem += $"{item.Name} * {item.Quantity} = {item.Price * item.Quantity}#";
			}
			orderItem += $"運費 = {data1.ShippingFee}#購物金 = -{UseShoppingMoney}";
			var orderId = data1.Number;
			string PaymentName = "";
			string ShippingName = "";


			var order = new Dictionary<string, string>
			{
                //綠界需要的參數
                { "MerchantTradeNo",  orderId},
				{ "MerchantTradeDate",  DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")},
				{ "TotalAmount",  data1.Total.ToString()},
				{ "TradeDesc",  "無"},
				{ "ItemName",  orderItem},
				{ "ReturnURL",  "https://msit51-t1bt-asp-ecp.azurewebsites.net/cart/PayInfo"},
				{ "ClientBackURL",  "http://localhost:8080/cart/Step3"},
				{ "MerchantID",  "2000132"},
				{ "PaymentType",  "aio"},
				{ "EncryptType",  "1"},
				{ "CustomField1",  MemberID.ToString()},
			};
			switch (PaymentType) {
				case 1:
					order["ChoosePayment"] = "Credit";
					PaymentName = "信用卡";
					break;
				case 2:
					order["ChoosePayment"] = "ATM";
					PaymentName = "ATM";
					break;
				case 3:
					order["ChoosePayment"] = "CVS";
					PaymentName = "超商代碼";
					break;
				case 4:
					order["ChoosePayment"] = "BARCODE";
					PaymentName = "超商條碼";
					break;
			}

			switch (ShippingType) {
				case 1:
					ShippingName = "宅配";
					break;
				case 2:
					ShippingName = "超商";
					break;

			}
			// 檢查碼
			order["CheckMacValue"] = GetCheckMacValue(order);
			// 新增payment
			Payment Addpayment = new Payment() {
				EcpayName = orderId,
				Name = PaymentName,
				Sort = 0,
				Enable = true,
			};

			_context.Payment.Add(Addpayment);
			await _context.SaveChangesAsync();
			// 找到剛新增的payment
			var pay = _context.Payment
					   .OrderBy(x => x.ID)
					   .Last();
			data1.PaymentType = pay.ID;


			// 新增shipping
			Shipping Addshipping = new Shipping() {
				EcpayName = orderId,
				AllowPayment = "[1,2,3,4]",
				Name = ShippingName,
				Fee = data1.ShippingFee,
				Sort = 0,
				Enable = true,
			};

			_context.Shipping.Add(Addshipping);
			await _context.SaveChangesAsync();
			// 找到剛新增的shipping
			var ship = _context.Shipping
					   .OrderBy(x => x.ID)
					   .Last();
			data1.ShippingType = ship.ID;

			await _context.SaveChangesAsync();

			// 更新會員購物金
			var member = await _context.Member.FindAsync(MemberID);
			member.ShoppingMoney -= UseShoppingMoney;
			await _context.SaveChangesAsync();

			//依訂單產品更新數量 & 狀態
			Product product = null;
			UsedSale used = null;
			var data = _context.Cart
						.Where(x => x.MemberID == MemberID)
						.ToList();
			foreach (Cart x in data) {
				if (x.UsedID == null) {
					product = await _context.Product.FindAsync(x.ProductID);
					product.Stock -= x.Quantity;
					await _context.SaveChangesAsync();
				}
				else {
					used = await _context.UsedSale.FindAsync(x.UsedID);
					used.Sold = true;
					used.VerifyStatus = 2;
					await _context.SaveChangesAsync();
				}
				// 清空購物車
				_context.Cart.Remove(x);
				await _context.SaveChangesAsync();
			}

			return order;


		}

		// 付款回傳，更新訂單狀態，此api需使用外部IP，不可使用localhost
		[HttpPost]
		public async Task<ActionResult> PayInfo() {
			string temp = Request.Form["MerchantTradeNo"]; //寫在LINQ(下一行)會出錯，
			var ecpayOrder = _context.OrderForm.Where(m => m.Number == temp).FirstOrDefault();
			if (ecpayOrder != null) {
				ecpayOrder.PaymentTime = Convert.ToDateTime(Request.Form["PaymentDate"]);
				if ((int.Parse(Request.Form["RtnCode"]) == 1)) { ecpayOrder.PaymentStatus = true; }

				await _context.SaveChangesAsync();
			}

			return Content("1|OK");
		}

		// 發送物流訂單到綠界  做完發現用不到
		[HttpPost]
		public Dictionary<string, string> AddCVSShipping(string LogisticsSubType, int Total, string ReceiveName, string ReceivePhone) {

			var data1 = _context.OrderForm
					   .Where(x => x.MemberID == 1)
					   .OrderBy(x => x.ID)
					   .Last();
			var order = new Dictionary<string, string>
			{
                //綠界需要的參數
				{ "MerchantID",  "2000132"},
				{ "MerchantTradeNo",  data1.Number},
				{ "MerchantTradeDate",  DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")},
				{ "LogisticsType", "CVS"},
				{ "GoodsAmount", Total.ToString()},
				{ "SenderName", "ReadUse"},
				{ "ReceiverName", ReceiveName},
				{ "ReceiverCellPhone", ReceivePhone},
				{ "ServerReplyURL", "https://localhost:7038/cart/CVSInfo"}
			};
			switch (LogisticsSubType) {
				case "萊爾富":
					order["LogisticsSubType"] = "HILIFE";
					order["ReceiverStoreID"] = "2001";
					break;
				case "全家":
					order["LogisticsSubType"] = "FAMI";
					order["ReceiverStoreID"] = "006598";
					break;
				case "統一超商":
					order["LogisticsSubType"] = "UNIMART";
					order["ReceiverStoreID"] = "131386";
					break;
			}

			order["CheckMacValue"] = GetCheckMacValueMD5(order);


			return order;

		}
		// 物流回傳，更新訂單狀態，不可使用localhost  做完發現用不到
		[HttpPost]
		public ActionResult CVSInfo() {
			string temp = Request.Form["MerchantTradeNo"]; //寫在LINQ(下一行)會出錯，
			var ecpayOrder = _context.OrderForm.Where(m => m.Number == temp).FirstOrDefault();
			if (ecpayOrder != null) {
				ecpayOrder.PaymentTime = Convert.ToDateTime(Request.Form["PaymentDate"]);
				if ((int.Parse(Request.Form["RtnCode"]) == 1)) { ecpayOrder.PaymentStatus = true; }

				_context.SaveChanges();
			}
			return Content("1|OK");
		}
	}
}