using ECPay.Payment.Integration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSIT51BT_ASP.Libraries;
using MSIT51BT_ASP.Models;
using System.Collections;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MSIT51BT_ASP.Controllers {
	partial class BackController {
		// 取得標題資料
		public JsonResult GetOrderFormPageData() {
			return Json(new {
				title = "訂單管理",
				creatable = false,
				deletable = false,
			});
		}

		// 取得內容欄位資料
		public JsonResult GetOrderFormContentFieldData() {
			List<BackField> Data = new List<BackField>();
			Data.Add(new BackField {
				Type = BackFieldType.Input,
				FieldName = "Number",
				Name = "訂單編號",
				ColSize = 12,
				ReadOnly = true,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Input,
				FieldName = "Account",
				Name = "會員帳號",
				ColSize = 4,
				ReadOnly = true,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Input,
				FieldName = "Name",
				Name = "會員姓名",
				ColSize = 4,
				ReadOnly = true,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Input,
				FieldName = "Phone",
				Name = "會員電話",
				ColSize = 4,
				ReadOnly = true,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Input,
				FieldName = "ShippingFee",
				Name = "運費",
				ColSize = 4,
				ReadOnly = true,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Input,
				FieldName = "SubTotal",
				Name = "小計",
				ColSize = 4,
				ReadOnly = true,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Input,
				FieldName = "Total",
				Name = "總額",
				ColSize = 4,
				ReadOnly = true,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Input,
				FieldName = "PaymentName",
				Name = "付款方式",
				ColSize = 4,
				ReadOnly = true,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Input,
				FieldName = "ShippingName",
				Name = "貨運方式",
				ColSize = 4,
				ReadOnly = true,
				CutCol = true,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Input,
				FieldName = "ReceiveName",
				Name = "收件人姓名",
				ColSize = 4,
				ReadOnly = true,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Input,
				FieldName = "ReceiveEmail",
				Name = "收件人信箱",
				ColSize = 4,
				ReadOnly = true,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Input,
				FieldName = "ReceivePhone",
				Name = "收件人電話",
				ColSize = 4,
				ReadOnly = true,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Input,
				FieldName = "ReceiveCounty",
				Name = "收件人縣市",
				ColSize = 4,
				ReadOnly = true,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Input,
				FieldName = "ReceiveDistrict",
				Name = "收件人地區",
				ColSize = 4,
				ReadOnly = true,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Input,
				FieldName = "ReceiveZipcode",
				Name = "收件人區碼",
				ColSize = 4,
				ReadOnly = true,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Input,
				FieldName = "ReceiveAddress",
				Name = "收件人地址",
				ColSize = 6,
				ReadOnly = true,
				CutCol = true,
			});

			Data.Add(new BackField {
				Type = BackFieldType.OrderDetail,
				FieldName = "OrderDetail",
				Name = "訂單細項",
				ColSize = 12,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Textarea,
				FieldName = "Remark",
				Name = "備註",
				ColSize = 12,
				ReadOnly = true,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Switch,
				FieldName = "PaymentStatus",
				Name = "付款狀態",
				ColSize = 3,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Select,
				FieldName = "Status",
				Name = "訂單狀態",
				ColSize = 3,
				CutCol = true,
				RefKey = "DataValue",
				RefTable = "OrderStatus",
				RefField = "DataName",
			});

			Data.Add(new BackField {
				Type = BackFieldType.Switch,
				FieldName = "Enable",
				Name = "啟用",
				ColSize = 2,
			});

			return Json(Data);
		}

		// 取得列表欄位資料
		public JsonResult GetOrderFormListFieldData() {
			List<BackField> Data = new List<BackField>();
			Data.Add(new BackField {
				Type = BackFieldType.Text,
				FieldName = "Number",
				Name = "訂單編號",
			});
			Data.Add(new BackField {
				Type = BackFieldType.Text,
				FieldName = "ReceiveName",
				Name = "收件人姓名",
			});
			Data.Add(new BackField {
				Type = BackFieldType.Text,
				FieldName = "Total",
				Name = "總額",
			});

			Data.Add(new BackField {
				Type = BackFieldType.Text,
				FieldName = "StatusName",
				Name = "訂單狀態",
			});

			Data.Add(new BackField {
				Type = BackFieldType.OX,
				FieldName = "PaymentStatus",
				Name = "付款狀態",
			});

			return Json(Data);
		}

		// 取得列表搜尋欄位資料
		public JsonResult GetOrderFormListSearchFieldData() {
			List<BackField> Data = new List<BackField>();

			Data.Add(new BackField {
				Type = BackFieldType.SearchInput,
				FieldName = "Number",
				Name = "訂單編號",
				ColSize = 3,
			});

			Data.Add(new BackField {
				Type = BackFieldType.SearchSelect,
				FieldName = "Status",
				Name = "訂單狀態",
				ColSize = 3,
				RefKey = "DataValue",
				RefTable = "OrderStatus",
				RefField = "DataName",
			});

			Hashtable searchData = new Hashtable();

			// 取得訂單狀態資料
			var orderStatus = _context.Config
						.Where(x => x.DataCategory == "OrderStatus")
						.Select(x => x)
						.ToList();
			searchData.Add("OrderStatus", orderStatus);

			return Json(new { searchFieldData = Data, searchData = searchData });
		}

		// 取得內容資料
		public JsonResult GetOrderFormContentData(int id) {
			Hashtable data = new Hashtable();

			//取得內容資料
			var item = _context.OrderForm
						.Join(_context.Member,
							orderForm => orderForm.MemberID,
							member => member.ID,
							(orderForm, member) => new { OrderFormItem = orderForm, MemberItem = member })
						.Join(_context.Payment,
							orderForm => orderForm.OrderFormItem.PaymentType,
							payment => payment.ID,
							(orderForm, payment) => new { OrderFormItem = orderForm.OrderFormItem, MemberItem = orderForm.MemberItem, PaymentItem = payment })
						.Join(_context.Shipping,
							orderForm => orderForm.OrderFormItem.ShippingType,
							shipping => shipping.ID,
							(orderForm, shipping) => new { OrderFormItem = orderForm.OrderFormItem, MemberItem = orderForm.MemberItem, PaymentItem = orderForm.PaymentItem, ShippingItem = shipping })
						.Where(x => x.OrderFormItem.ID == id)
						.Select(x => new {
							x.OrderFormItem.ID,
							x.OrderFormItem.Number,
							x.MemberItem.Account,
							x.MemberItem.Name,
							x.MemberItem.Phone,
							x.OrderFormItem.ShippingFee,
							x.OrderFormItem.SubTotal,
							x.OrderFormItem.Total,
							PaymentName = x.PaymentItem.Name,
							ShippingName = x.ShippingItem.Name,
							x.OrderFormItem.ShippingType,
							x.OrderFormItem.ReceiveName,
							x.OrderFormItem.ReceiveEmail,
							x.OrderFormItem.ReceivePhone,
							x.OrderFormItem.ReceiveCounty,
							x.OrderFormItem.ReceiveDistrict,
							x.OrderFormItem.ReceiveZipcode,
							x.OrderFormItem.ReceiveAddress,
							x.OrderFormItem.Remark,
							x.OrderFormItem.PaymentStatus,
							x.OrderFormItem.Status,
							x.OrderFormItem.Enable,
						})
						.FirstOrDefault();
			data.Add("item", item);

			// 取得訂單狀態資料
			var config = _context.Config
						.Where(x => x.DataCategory == "OrderStatus")
						.Select(x => x)
						.ToList();
			data.Add("OrderStatus", config);

			// 取得訂單細項資料
			var orderDetail = _context.OrderDetail
						.Join(_context.Product,
							orderDetail => orderDetail.ProductID,
							product => product.ID,
							(orderDetail, product) => new { OrderDetailItem = orderDetail, ProductItem = product })
						.Where(x => x.OrderDetailItem.OrderFormID == item.ID)
						.Select(x => new {
							x.OrderDetailItem.ID,
							ProductImg = x.ProductItem.Img1 != null ? MyHelper.GetFilePath(HttpContext, x.ProductItem.Img1) : "",
							x.OrderDetailItem.ProductName,
							x.OrderDetailItem.Quantity,
							x.OrderDetailItem.SalePrice,
						})
						.ToList();
			data.Add("OrderDetail", orderDetail);

			return Json(data);
		}

		// 取得列表資料
		public JsonResult GetOrderFormListData() {
			int page = Convert.ToInt16(HttpContext.Request.Query["page"]); // 當前頁數
			if (page <= 0) page = 1;

			var data = _context.OrderForm
					.Join(_context.Config,
							orderForm => orderForm.Status,
							config => config.DataValue,
							(orderForm, config) => new { OrderFormItem = orderForm, ConfigItem = config })
					.Where(x => x.ConfigItem.DataCategory == "OrderStatus")
					.OrderByDescending(x => x.OrderFormItem.CreateTime)
					.Select(x => new {
						item = new {
							ID = x.OrderFormItem.ID,
							Number = x.OrderFormItem.Number,
							ReceiveName = x.OrderFormItem.ReceiveName,
							Total = x.OrderFormItem.Total,
							Sort = x.OrderFormItem.Sort,
							PaymentStatus = x.OrderFormItem.PaymentStatus,
							StatusName = x.ConfigItem.DataName,
							Status = x.OrderFormItem.Status,
							Enable = x.OrderFormItem.Enable,
						},
					});

			// 搜尋 Number
			var searchNumber = HttpContext.Request.Query["Number"];
			if (searchNumber.Count != 0 && searchNumber != "") {
				data = data.Where(x => x.item.Number.Contains(searchNumber.ToString()));
			}

			// 搜尋 Status
			var searchStatus = HttpContext.Request.Query["Status"];
			if (searchStatus.Count != 0 && searchStatus != "") {
				data = data.Where(x => x.item.Status == Convert.ToInt16(searchStatus));
			}

			// 分頁
			data = data.Skip((page - 1) * pageSize)
					.Take(pageSize);

			return Json(data);
		}

		// 取得分頁資料
		public JsonResult GetOrderFormPaginationData() {
			var totoRow = _context.OrderForm
							.Select(x => x);

			// 搜尋 Number
			var searchNumber = HttpContext.Request.Query["Number"];
			if (searchNumber.Count != 0 && searchNumber != "") {
				totoRow = totoRow.Where(x => x.Number.Contains(searchNumber.ToString()));
			}

			// 搜尋 Status
			var searchStatus = HttpContext.Request.Query["Status"];
			if (searchStatus.Count != 0 && searchStatus != "") {
				totoRow = totoRow.Where(x => x.Status == Convert.ToInt16(searchStatus));
			}

			var data = new {
				totalRow = totoRow.Count(),
				pageSize = pageSize
			};

			return Json(data);
		}

		// 編輯
		[HttpPost]
		//[ValidateAntiForgeryToken]
		public async Task<JsonResult> EditOrderFormContentData(int id, [Bind("PaymentStatus,Status,Enable")] OrderForm orderForm) {
			var data = _context.OrderForm
						.Where(x => x.ID == id);
			OrderForm update = data.FirstOrDefault();

			if (update == null) {
				return Json(new { result = "info", title = "查無此項目" });
			}

			try {
				// 更改成訂單完成時添加訂單內容至書櫃
				if (update.Status != 2 && orderForm.Status == 2) {
					// 訂單細項
					var orderDetail = _context.OrderDetail
						.Where(x => x.OrderFormID == id)
						.ToList();

					// 如果是二手書販售 則添加該筆販售價
					foreach (var item in orderDetail) {
						if (item.Type == "Customer") {
							UsedSale? usedSale = _context.UsedSale
									.Where(x => x.ID == item.UsedID)
									.Where(x => x.WithdrawType == "ShoppingMoney")
									.FirstOrDefault();
							if(usedSale != null) {
								//會員資料
								Member? member = _context.Member
										.Where(x => x.ID == usedSale.MemberID)
										.FirstOrDefault();
								if (member == null) {
									return Json(new { result = "info", title = "查無此會員" });
								}

								member.ShoppingMoney = member.ShoppingMoney + (int)Math.Round(usedSale.SalePrice * 0.7);
								_context.Update(member);
								await _context.SaveChangesAsync();
							}
						}
					}

					// 購買後自動添加至書櫃
					foreach (var item in orderDetail) {
						// 先偵測書櫃中是否已有該本書
						Bookcase? chkRepeat = _context.Bookcase
											.Where(x => x.MemberID == update.MemberID)
											.Where(x => x.ProductID == item.ProductID)
											.FirstOrDefault();
						if (chkRepeat == null) {
							Bookcase bookcase = new Bookcase() {
								MemberID = update.MemberID,
								ProductID = item.ProductID,
								Enable = true,
							};

							_context.Update(bookcase);
							await _context.SaveChangesAsync();
						}
					}
				}

				update.PaymentStatus = orderForm.PaymentStatus;
				update.Status = orderForm.Status;
				update.Enable = orderForm.Enable;

				_context.Update(update);
				await _context.SaveChangesAsync();

				return Json(new { result = "success", title = "更新成功" });
			}
			catch (DbUpdateConcurrencyException) {
				return Json(new { result = "info", title = "更新失敗" });
			}
		}



	}
}
