using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSIT51BT_ASP.Libraries;
using MSIT51BT_ASP.Models;
using System.Collections;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MSIT51BT_ASP.Controllers {
	partial class BackController {
		// 取得標題資料
		public JsonResult GetNewsPageData() {
			return Json(new {
				title = "最新消息",
				creatable = true,
				deletable = true,
			});
		}

		// 取得內容欄位資料
		public JsonResult GetNewsContentFieldData() {
			List<BackField> Data = new List<BackField>();
			Data.Add(new BackField {
				Type = BackFieldType.Select,
				FieldName = "NewsCategoryID",
				Name = "分類",
				ColSize = 12,
				CutCol = false,
				ReadOnly = false,
				RefKey = "ID",
				RefTable = "NewsCategory",
				RefField = "Name",
			});

			Data.Add(new BackField {
				Type = BackFieldType.Input,
				FieldName = "Name",
				Name = "名稱",
				ColSize = 12,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Upload,
				FieldName = "Img1",
				Name = "圖片",
				ColSize = 3,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Textarea,
				FieldName = "Content",
				Name = "內容",
				ColSize = 12,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Datepicker,
				FieldName = "StartDate",
				Name = "開始日期",
				ColSize = 6,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Datepicker,
				FieldName = "EndDate",
				Name = "結束日期",
				ColSize = 6,
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
		public JsonResult GetNewsListFieldData() {
			List<BackField> Data = new List<BackField>();
			Data.Add(new BackField {
				Type = BackFieldType.Text,
				FieldName = "CategoryName",
				Name = "分類",
			});

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
		public JsonResult GetNewsListSearchFieldData() {
			List<BackField> Data = new List<BackField>();

			Hashtable searchData = new Hashtable();

			return Json(new { searchFieldData = Data, searchData = searchData });
		}

		// 取得內容資料
		public JsonResult GetNewsContentData(int id) {
			Hashtable data = new Hashtable();

			//取得內容資料
			var item = _context.News
						.Where(x => x.ID == id)
						.Select(x => x).FirstOrDefault();
			// 如果無此項目則給予預設值
			if (item == null) {
				data.Add("item", new News() { Enable = true });
			}
			else {
				if (item != null && item.Img1 != null) {
					item.Img1 = MyHelper.GetFilePath(HttpContext, item.Img1);
				}
				data.Add("item", item);
			}

			// 取得分類資料
			var newsCategory = _context.NewsCategory
						.Select(x => x);
			data.Add("NewsCategory", newsCategory);

			return Json(data);
		}

		// 取得列表資料
		public JsonResult GetNewsListData() {
			int page = Convert.ToInt16(HttpContext.Request.Query["page"]); // 當前頁數
			if (page <= 0) page = 1;

			var data = _context.News
					.Join(_context.NewsCategory,
						news => news.NewsCategoryID,
						category => category.ID,
						(news, category) => new { NewsItem = news, CategoryItem = category })
					.OrderBy(x => x.NewsItem.Sort)
					.ThenByDescending(x => x.NewsItem.CreateTime)
					.Select(x => new {
						item = new {
							ID = x.NewsItem.ID,
							CategoryName = x.CategoryItem.Name,
							Name = x.NewsItem.Name,
							Sort = x.NewsItem.Sort,
							Enable = x.NewsItem.Enable,
						},
					});

			// 分頁
			data = data.Skip((page - 1) * pageSize)
					.Take(pageSize);

			return Json(data);
		}

		// 取得分頁資料
		public JsonResult GetNewsPaginationData() {
			var totoRow = _context.News
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
		public async Task<JsonResult> CreateNewsContentData([Bind("NewsCategoryID,Name,Img1,Content,StartDate,EndDate,Sort,Enable")] News news) {
			if (ModelState.IsValid) {
				// 檔案上傳
				try {
					if (Request.Form.Files["Img1"] != null) {
						IFormFile file = Request.Form.Files["Img1"]!;

						while (true) {
							string fileName = MyHelper.GetRandomChar(30) + Path.GetExtension(file.FileName);
							string relativePath = Path.Combine(uploadPath, fileName);
							string filePath = Path.Combine(_env.WebRootPath, relativePath);

							if (!System.IO.File.Exists(filePath)) {
								using Stream fileStream = System.IO.File.Create(filePath);
								file.CopyTo(fileStream);
								fileStream.Close();

								news.Img1 = relativePath;
								break;
							}
						}
					}
				}
				catch (Exception e) {
					return Json(new { result = "info", title = "檔案上傳失敗" });
				}

				_context.Add(news);
				await _context.SaveChangesAsync();

				return Json(new { result = "success", title = "送出成功", ID = news.ID });
			}

			var ModelStateErrors = ModelState.Where(x => x.Value.Errors.Count > 0)
			.ToDictionary(k => k.Key, k => k.Value.Errors.Select(e => e.ErrorMessage).ToArray());

			return Json(new { result = "error", title = "送出失敗，請檢查欄位", data = ModelStateErrors });
		}

		// 編輯
		[HttpPost]
		//[ValidateAntiForgeryToken]
		public async Task<JsonResult> EditNewsContentData(int id, [Bind("NewsCategoryID,Name,Img1,Content,StartDate,EndDate,Sort,Enable")] News news) {
			var data = _context.News
						.Where(x => x.ID == id);
			News update = data.FirstOrDefault();

			if (update == null) {
				return Json(new { result = "info", title = "查無此項目" });
			}

			if (ModelState.IsValid) {
				try {
					update.NewsCategoryID = news.NewsCategoryID;
					update.Name = news.Name;
					update.Content = news.Content;
					update.StartDate = news.StartDate;
					update.EndDate = news.EndDate;
					update.Enable = news.Enable;
					update.Sort = news.Sort;

					// 檔案上傳
					try {
						if (Request.Form.Files["Img1"] != null) {
							IFormFile file = Request.Form.Files["Img1"]!;

							while (true) {
								string fileName = MyHelper.GetRandomChar(30) + Path.GetExtension(file.FileName);
								string relativePath = Path.Combine(uploadPath, fileName);
								string filePath = Path.Combine(_env.WebRootPath, relativePath);

								if (!System.IO.File.Exists(filePath)) {
									using Stream fileStream = System.IO.File.Create(filePath);
									file.CopyTo(fileStream);
									fileStream.Close();

									update.Img1 = relativePath;
									break;
								}
							}
						}
					}
					catch (Exception e) {
						return Json(new { result = "info", title = "檔案上傳失敗" });
					}

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
		public async Task<JsonResult> EditNewsSort(int id, [Bind("Sort")] int sort) {
			var data = _context.News
						.Where(x => x.ID == id);
			News update = data.FirstOrDefault();

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
		public async Task<JsonResult> DeleteNewsByID(int id) {
			if (_context.News == null) {
				return Json(new { result = "info", title = "查無此項目" });
			}
			var news = await _context.News.FindAsync(id);
			if (news == null) {
				return Json(new { result = "info", title = "查無此項目" });
			}

			_context.News.Remove(news);
			await _context.SaveChangesAsync();
			return Json(new { result = "success", title = "刪除成功" });
		}



	}
}
