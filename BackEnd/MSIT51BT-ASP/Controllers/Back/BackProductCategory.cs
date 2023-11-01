using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSIT51BT_ASP.Libraries;
using MSIT51BT_ASP.Models;
using System.Collections;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MSIT51BT_ASP.Controllers {
	partial class BackController {
		// 取得標題資料
		public JsonResult GetProductCategoryPageData() {
			return Json(new {
				title = "書籍分類",
				creatable = true,
				deletable = true,
			});
		}

		// 取得內容欄位資料
		public JsonResult GetProductCategoryContentFieldData() {
			List<BackField> Data = new List<BackField>();
			Data.Add(new BackField {
				Type = BackFieldType.Input,
				FieldName = "Name",
				Name = "名稱",
				ColSize = 12,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Number,
				FieldName = "Sort",
				Name = "排序",
				ColSize = 2,
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
		public JsonResult GetProductCategoryListFieldData() {
			List<BackField> Data = new List<BackField>();
			Data.Add(new BackField {
				Type = BackFieldType.Text,
				FieldName = "Name",
				Name = "名稱",
			});

			Data.Add(new BackField {
				Type = BackFieldType.Sort,
				FieldName = "Sort",
				Name = "排序",
			});

			return Json(Data);
		}

		// 取得列表搜尋欄位資料
		public JsonResult GetProductCategoryListSearchFieldData() {
			List<BackField> Data = new List<BackField>();

			Hashtable searchData = new Hashtable();

			return Json(new { searchFieldData = Data, searchData = searchData });
		}

		// 取得內容資料
		public JsonResult GetProductCategoryContentData(int id) {
			Hashtable data = new Hashtable();

			//取得內容資料
			var item = _context.ProductCategory
						.Where(x => x.ID == id)
						.Select(x => x).FirstOrDefault();
			// 如果無此項目則給予預設值
			if (item == null) {
				data.Add("item", new ProductCategory() { Enable = true });
			}
			else {
				data.Add("item", item);
			}

			return Json(data);
		}

		// 取得列表資料
		public JsonResult GetProductCategoryListData() {
			int page = Convert.ToInt16(HttpContext.Request.Query["page"]); // 當前頁數
			if (page <= 0) page = 1;

			var data = _context.ProductCategory
					.OrderBy(x => x.Sort)
					.ThenByDescending(x => x.CreateTime)
					.Select(x => new {
						item = new {
							ID = x.ID,
							Name = x.Name,
							Sort = x.Sort,
							Enable = x.Enable,
						},
					});

			// 分頁
			data = data.Skip((page - 1) * pageSize)
					.Take(pageSize);

			return Json(data);
		}

		// 取得分頁資料
		public JsonResult GetProductCategoryPaginationData() {
			var totoRow = _context.ProductCategory
							.Select(x => x);

			var data = new {
				totalRow = totoRow.Count(),
				pageSize = pageSize
			};

			return Json(data);
		}

		// 新增
		[HttpPost]
		//[ValidateAntiForgeryToken]
		public async Task<JsonResult> CreateProductCategoryContentData([Bind("Name,Sort,Enable")] ProductCategory productCategory) {
			if (ModelState.IsValid) {
				_context.Add(productCategory);
				await _context.SaveChangesAsync();

				return Json(new { result = "success", title = "送出成功", ID = productCategory.ID });
			}

			var ModelStateErrors = ModelState.Where(x => x.Value.Errors.Count > 0)
			.ToDictionary(k => k.Key, k => k.Value.Errors.Select(e => e.ErrorMessage).ToArray());

			return Json(new { result = "error", title = "送出失敗，請檢查欄位", data = ModelStateErrors });
		}

		// 編輯
		[HttpPost]
		//[ValidateAntiForgeryToken]
		public async Task<JsonResult> EditProductCategoryContentData(int id, [Bind("Name,Enable,Sort")] ProductCategory productCategory) {
			var data = _context.ProductCategory
						.Where(x => x.ID == id);
			ProductCategory update = data.FirstOrDefault();

			if (update == null) {
				return Json(new { result = "info", title = "查無此項目" });
			}

			if (ModelState.IsValid) {
				try {
					update.Name = productCategory.Name;
					update.Enable = productCategory.Enable;
					update.Sort = productCategory.Sort;

					_context.Update(update);
					await _context.SaveChangesAsync();

					return Json(new { result = "success", title = "更新成功" });
				}
				catch (DbUpdateConcurrencyException) {
					return Json(new { result = "info", title = "更新失敗" });
				}
			}

			var ModelStateErrors = ModelState.Where(x => x.Value.Errors.Count > 0)
			.ToDictionary(k => k.Key, k => k.Value.Errors.Select(e => e.ErrorMessage).ToArray());

			return Json(new { result = "error", title = "送出失敗，請檢查欄位", data = ModelStateErrors });
		}

		// 更新排序
		[HttpPost]
		//[ValidateAntiForgeryToken]
		public async Task<JsonResult> EditProductCategorySort(int id, [Bind("Sort")] int sort) {
			var data = _context.ProductCategory
						.Where(x => x.ID == id);
			ProductCategory update = data.FirstOrDefault();

			if (update == null) {
				return Json(new { result = "info", title = "查無此項目" });
			}

			if (ModelState.IsValid) {
				try {
					update.Sort = sort;

					_context.Update(update);
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
		// [ValidateAntiForgeryToken]
		public async Task<JsonResult> DeleteProductCategoryByID(int id) {
			if (_context.ProductCategory == null) {
				return Json(new { result = "info", title = "查無此項目" });
			}
			var productCategory = await _context.ProductCategory.FindAsync(id);
			if (productCategory == null) {
				return Json(new { result = "info", title = "查無此項目" });
			}

			_context.ProductCategory.Remove(productCategory);
			await _context.SaveChangesAsync();
			return Json(new { result = "success", title = "刪除成功" });
		}



	}
}
