using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSIT51BT_ASP.Libraries;
using MSIT51BT_ASP.Models;
using System.Collections;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MSIT51BT_ASP.Controllers {
	partial class BackController {
		// 取得標題資料
		public JsonResult GetUsedSalePageData() {
			return Json(new {
				title = "二手書販售",
				creatable = false,
				deletable = true,
			});
		}

		// 取得內容欄位資料
		public JsonResult GetUsedSaleContentFieldData() {
			List<BackField> Data = new List<BackField>();

			Data.Add(new BackField {
				Type = BackFieldType.Input,
				FieldName = "ProductName",
				Name = "書籍名稱",
				ColSize = 12,
				ReadOnly = true,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Input,
				FieldName = "MemberAccount",
				Name = "會員帳號",
				ColSize = 3,
				ReadOnly = true,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Input,
				FieldName = "MemberName",
				Name = "會員姓名",
				ColSize = 3,
				ReadOnly = true,
				CutCol = true
			});

			Data.Add(new BackField {
				Type = BackFieldType.Input,
				FieldName = "BookStatus",
				Name = "書況",
				ColSize = 3,
				ReadOnly = true,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Select,
				FieldName = "VerifyStatus",
				Name = "審核狀態",
				ColSize = 3,
				RefKey = "DataValue",
				RefTable = "BookVerifyStatus",
				RefField = "DataName",
			});

			Data.Add(new BackField {
				Type = BackFieldType.Switch,
				FieldName = "Sold",
				Name = "已售出",
				ColSize = 2,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Input,
				FieldName = "SalePrice",
				Name = "販售價格",
				ColSize = 12,
				ReadOnly = true,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Upload,
				FieldName = "Img1",
				Name = "書況圖1",
				ColSize = 4,
				ReadOnly = true,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Upload,
				FieldName = "Img2",
				Name = "書況圖2",
				ColSize = 4,
				ReadOnly = true,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Upload,
				FieldName = "Img3",
				Name = "書況圖3",
				ColSize = 4,
				ReadOnly = true,
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
		public JsonResult GetUsedSaleListFieldData() {
			List<BackField> Data = new List<BackField>();
			Data.Add(new BackField {
				Type = BackFieldType.Text,
				FieldName = "ProductName",
				Name = "書籍名稱",
			});

			Data.Add(new BackField {
				Type = BackFieldType.Text,
				FieldName = "MemberAccount",
				Name = "會員帳號",
			});

			Data.Add(new BackField {
				Type = BackFieldType.Text,
				FieldName = "BookStatus",
				Name = "書況",
			});

			Data.Add(new BackField {
				Type = BackFieldType.Text,
				FieldName = "VerifyStatusName",
				Name = "審核狀態",
			});

			return Json(Data);
		}

		// 取得列表搜尋欄位資料
		public JsonResult GetUsedSaleListSearchFieldData() {
			List<BackField> Data = new List<BackField>();
			Data.Add(new BackField {
				Type = BackFieldType.SearchSelect,
				FieldName = "VerifyStatus",
				Name = "審核狀態",
				ColSize = 3,
				RefKey = "DataValue",
				RefTable = "BookVerifyStatus",
				RefField = "DataName",
			});

			Hashtable searchData = new Hashtable();
			// 取得審核狀態資料
			var bookVerifyStatus = _context.Config
						.Where(x => x.DataCategory == "BookVerifyStatus")
						.Select(x => x)
						.ToList();
			searchData.Add("BookVerifyStatus", bookVerifyStatus);

			return Json(new { searchFieldData = Data, searchData = searchData });
		}

		// 取得內容資料
		public JsonResult GetUsedSaleContentData(int id) {
			Hashtable data = new Hashtable();

			//取得內容資料
			var item = _context.UsedSale
						.Join(_context.Member,
							usedSale => usedSale.MemberID,
							member => member.ID,
							(usedSale, member) => new { UsedSaleItem = usedSale, MemberItem = member })
						.Join(_context.Product,
								usedSale => usedSale.UsedSaleItem.ProductID,
								product => product.ID,
								(usedSale, product) => new { UsedSaleItem = usedSale.UsedSaleItem, MemberItem = usedSale.MemberItem, ProductItem = product })
						.Join(_context.Config,
								usedSale => usedSale.UsedSaleItem.BookStatus,
								bookStatus => bookStatus.DataValue,
								(usedSale, bookStatus) => new { UsedSaleItem = usedSale.UsedSaleItem, MemberItem = usedSale.MemberItem, ProductItem = usedSale.ProductItem, BookStatusItem = bookStatus })
						.Join(_context.Config,
								usedSale => usedSale.UsedSaleItem.VerifyStatus,
								verifyStatus => verifyStatus.DataValue,
								(usedSale, verifyStatus) => new { UsedSaleItem = usedSale.UsedSaleItem, MemberItem = usedSale.MemberItem, ProductItem = usedSale.ProductItem, BookStatusItem = usedSale.BookStatusItem, VerifyStatusItem = verifyStatus })
						.Where(x => x.BookStatusItem.DataCategory == "BookStatus")
						.Where(x => x.VerifyStatusItem.DataCategory == "BookVerifyStatus")
						.Where(x => x.UsedSaleItem.ID == id)
						.Select(x => new {
							ID = x.UsedSaleItem.ID,
							ProductName = x.ProductItem.Name,
							MemberAccount = x.MemberItem.Account,
							MemberName = x.MemberItem.Name,
							BookStatus = x.BookStatusItem.DataName,
							VerifyStatus = x.VerifyStatusItem.DataValue,
							Sold = x.UsedSaleItem.Sold,
							SalePrice = x.UsedSaleItem.SalePrice,
							Img1 = x.UsedSaleItem.Img1 != null ? MyHelper.GetFilePath(HttpContext, x.UsedSaleItem.Img1) : "",
							Img2 = x.UsedSaleItem.Img2 != null ? MyHelper.GetFilePath(HttpContext, x.UsedSaleItem.Img2) : "",
							Img3 = x.UsedSaleItem.Img3 != null ? MyHelper.GetFilePath(HttpContext, x.UsedSaleItem.Img3) : "",
							Img4 = x.UsedSaleItem.Img4 != null ? MyHelper.GetFilePath(HttpContext, x.UsedSaleItem.Img4) : "",
							Img5 = x.UsedSaleItem.Img5 != null ? MyHelper.GetFilePath(HttpContext, x.UsedSaleItem.Img5) : "",
							Enable = x.UsedSaleItem.Enable,
						})
						.FirstOrDefault();
			// 如果無此項目則給予預設值
			if (item == null) {
				data.Add("item", new UsedSale() { Enable = true });
			}
			else {
				data.Add("item", item);
			}

			// 取得訂單狀態資料
			var config = _context.Config
						.Where(x => x.DataCategory == "BookVerifyStatus")
						.Select(x => x)
						.ToList();
			data.Add("BookVerifyStatus", config);

			return Json(data);
		}

		// 取得列表資料
		public JsonResult GetUsedSaleListData() {
			int page = Convert.ToInt16(HttpContext.Request.Query["page"]); // 當前頁數
			if (page <= 0) page = 1;

			var data = _context.UsedSale
					.Join(_context.Member,
							usedSale => usedSale.MemberID,
							member => member.ID,
							(usedSale, member) => new { UsedSaleItem = usedSale, MemberItem = member })
					.Join(_context.Product,
							usedSale => usedSale.UsedSaleItem.ProductID,
							product => product.ID,
							(usedSale, product) => new { UsedSaleItem = usedSale.UsedSaleItem, MemberItem = usedSale.MemberItem, ProductItem = product })
					.Join(_context.Config,
							usedSale => usedSale.UsedSaleItem.BookStatus,
							bookStatus => bookStatus.DataValue,
							(usedSale, bookStatus) => new { UsedSaleItem = usedSale.UsedSaleItem, MemberItem = usedSale.MemberItem, ProductItem = usedSale.ProductItem, BookStatusItem = bookStatus })
					.Join(_context.Config,
							usedSale => usedSale.UsedSaleItem.VerifyStatus,
							verifyStatus => verifyStatus.DataValue,
							(usedSale, verifyStatus) => new { UsedSaleItem = usedSale.UsedSaleItem, MemberItem = usedSale.MemberItem, ProductItem = usedSale.ProductItem, BookStatusItem = usedSale.BookStatusItem, VerifyStatusItem = verifyStatus })
					.Where(x => x.BookStatusItem.DataCategory == "BookStatus")
					.Where(x => x.VerifyStatusItem.DataCategory == "BookVerifyStatus")
					.OrderByDescending(x => x.UsedSaleItem.CreateTime)
					.Select(x => new {
						item = new {
							ID = x.UsedSaleItem.ID,
							ProductName = x.ProductItem.Name,
							MemberAccount = x.MemberItem.Account,
							BookStatus = x.BookStatusItem.DataName,
							VerifyStatusName = x.VerifyStatusItem.DataName,
							VerifyStatus = x.UsedSaleItem.VerifyStatus,
							Enable = x.UsedSaleItem.Enable,
						},
					});

			// 搜尋 VerifyStatus
			var searchVerifyStatus = HttpContext.Request.Query["VerifyStatus"];
			if (searchVerifyStatus.Count != 0 && searchVerifyStatus != "") {
				data = data.Where(x => x.item.VerifyStatus == Convert.ToInt16(searchVerifyStatus));
			}

			// 分頁
			data = data.Skip((page - 1) * pageSize)
					.Take(pageSize);

			return Json(data);
		}

		// 取得分頁資料
		public JsonResult GetUsedSalePaginationData() {
			var totoRow = _context.UsedSale
							.Select(x => x);

			// 搜尋 VerifyStatus
			var searchVerifyStatus = HttpContext.Request.Query["VerifyStatus"];
			if (searchVerifyStatus.Count != 0 && searchVerifyStatus != "") {
				totoRow = totoRow.Where(x => x.VerifyStatus == Convert.ToInt16(searchVerifyStatus));
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
		public async Task<JsonResult> EditUsedSaleContentData(int id, [Bind("VerifyStatus,Sold,Enable")] UsedSale usedSale) {
			var data = _context.UsedSale
						.Where(x => x.ID == id);
			UsedSale update = data.FirstOrDefault();

			if (update == null) {
				return Json(new { result = "info", title = "查無此項目" });
			}

			try {
				update.VerifyStatus = usedSale.VerifyStatus;
				update.Sold = usedSale.Sold;
				update.Enable = usedSale.Enable;

				_context.Update(update);
				await _context.SaveChangesAsync();

				return Json(new { result = "success", title = "更新成功" });
			}
			catch (DbUpdateConcurrencyException) {
				return Json(new { result = "info", title = "更新失敗" });
			}
		}

		[HttpPost]
		// [ValidateAntiForgeryToken]
		public async Task<JsonResult> DeleteUsedSaleByID(int id) {
			if (_context.UsedSale == null) {
				return Json(new { result = "info", title = "查無此項目" });
			}
			var usedSale = await _context.UsedSale.FindAsync(id);
			if (usedSale == null) {
				return Json(new { result = "info", title = "查無此項目" });
			}

			_context.UsedSale.Remove(usedSale);
			await _context.SaveChangesAsync();
			return Json(new { result = "success", title = "刪除成功" });
		}



	}
}
