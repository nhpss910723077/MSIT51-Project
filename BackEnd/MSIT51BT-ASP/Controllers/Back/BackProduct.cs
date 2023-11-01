using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSIT51BT_ASP.Libraries;
using MSIT51BT_ASP.Models;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MSIT51BT_ASP.Controllers {
	partial class BackController {
		// 取得標題資料
		public JsonResult GetProductPageData() {
			return Json(new {
				title = "書籍管理",
				creatable = true,
				deletable = true,
			});
		}

		// 取得內容欄位資料
		public JsonResult GetProductContentFieldData() {
			List<BackField> Data = new List<BackField>();
			Data.Add(new BackField {
				Type = BackFieldType.Select,
				FieldName = "ProductCategoryID",
				Name = "分類",
				ColSize = 6,
				CutCol = true,
				ReadOnly = false,
				RefKey = "ID",
				RefTable = "ProductCategory",
				RefField = "Name",
			});

			Data.Add(new BackField {
				Type = BackFieldType.ISBN,
				FieldName = "ISBN10",
				Name = "ISBN10",
				ColSize = 12,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Input,
				FieldName = "Name",
				Name = "名稱",
				ColSize = 12,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Number,
				FieldName = "ListPrice",
				Name = "原價",
				ColSize = 4,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Number,
				FieldName = "SalePrice",
				Name = "售價",
				ColSize = 4,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Number,
				FieldName = "Stock",
				Name = "庫存數量",
				ColSize = 4,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Input,
				FieldName = "Author",
				Name = "作者",
				ColSize = 6,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Input,
				FieldName = "Translator",
				Name = "譯者",
				ColSize = 6,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Input,
				FieldName = "Publisher",
				Name = "出版社",
				ColSize = 6,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Datepicker,
				FieldName = "PublishDate",
				Name = "出版日期",
				ColSize = 6,
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
				Name = "內容簡介",
				ColSize = 12,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Textarea,
				FieldName = "AuthorContent",
				Name = "作者簡介",
				ColSize = 12,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Textarea,
				FieldName = "Specification",
				Name = "書籍規格",
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
		public JsonResult GetProductListFieldData() {
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
		public JsonResult GetProductListSearchFieldData() {
			List<BackField> Data = new List<BackField>();

			Data.Add(new BackField {
				Type = BackFieldType.SearchInput,
				FieldName = "Name",
				Name = "名稱",
				ColSize = 3,
				ReadOnly = true,
			});

			Hashtable searchData = new Hashtable();

			return Json(new { searchFieldData = Data, searchData = searchData });
		}

		// 取得內容資料
		public JsonResult GetProductContentData(int id) {
			Hashtable data = new Hashtable();

			//取得內容資料
			var item = _context.Product
						.Where(x => x.ID == id)
						.Select(x => x).FirstOrDefault();
			// 如果無此項目則給予預設值
			if (item == null) {
				data.Add("item", new Product() { Enable = true });
			}
			else {
				if (item != null && item.Img1 != null) {
					item.Img1 = MyHelper.GetFilePath(HttpContext, item.Img1);
				}
				data.Add("item", item);
			}

			// 取得分類資料
			var productCategory = _context.ProductCategory
						.Select(x => x);
			data.Add("ProductCategory", productCategory);

			return Json(data);
		}

		// 取得列表資料
		public JsonResult GetProductListData() {
			int page = Convert.ToInt16(HttpContext.Request.Query["page"]); // 當前頁數
			if (page <= 0) page = 1;

			var data = _context.Product
					.Join(_context.ProductCategory,
						product => product.ProductCategoryID,
						category => category.ID,
						(product, category) => new { ProductItem = product, CategoryItem = category })
					.OrderBy(x => x.ProductItem.Sort)
					.ThenByDescending(x => x.ProductItem.CreateTime)
					.Select(x => new {
						item = new {
							ID = x.ProductItem.ID,
							CategoryName = x.CategoryItem.Name,
							Name = x.ProductItem.Name,
							Sort = x.ProductItem.Sort,
							Enable = x.ProductItem.Enable,
						},
					});

			// 搜尋 Name
			var searchName = HttpContext.Request.Query["Name"];
			if (searchName.Count != 0 && searchName != "") {
				data = data.Where(x => x.item.Name.Contains(searchName.ToString()));
			}

			// 分頁
			data = data.Skip((page - 1) * pageSize)
					.Take(pageSize);

			return Json(data);
		}

		// 取得分頁資料
		public JsonResult GetProductPaginationData() {
			var totoRow = _context.Product
							.Select(x => x);

			// 搜尋 Name
			var searchName = HttpContext.Request.Query["Name"];
			if (searchName.Count != 0 && searchName != "") {
				totoRow = totoRow.Where(x => x.Name.Contains(searchName.ToString()));
			}

			var data = new {
				totalRow = totoRow.Count(),
				pageSize = pageSize
			};

			return Json(data);
		}

		// 新增
		[HttpPost]
		//[ValidateAntiForgeryToken]
		public async Task<JsonResult> CreateProductContentData([Bind("ProductCategoryID,ISBN10,ISBN13,Name,ListPrice,SalePrice,Stock,Author,Translator,Publisher,PublishDate,Img1,Content,AuthorContent,Specification,Sort,Enable")] Product product) {
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

								product.Img1 = relativePath;
								break;
							}
						}
					}
				}
				catch (Exception e) {
					return Json(new { result = "info", title = "檔案上傳失敗" });
				}

				_context.Add(product);
				await _context.SaveChangesAsync();

				return Json(new { result = "success", title = "送出成功", ID = product.ID });
			}

			var ModelStateErrors = ModelState.Where(x => x.Value.Errors.Count > 0)
			.ToDictionary(k => k.Key, k => k.Value.Errors.Select(e => e.ErrorMessage).ToArray());

			return Json(new { result = "error", title = "送出失敗，請檢查欄位", data = ModelStateErrors });
		}

		// 編輯
		[HttpPost]
		//[ValidateAntiForgeryToken]
		public async Task<JsonResult> EditProductContentData(int id, [Bind("ProductCategoryID,ISBN10,ISBN13,Name,ListPrice,SalePrice,Stock,Author,Translator,Publisher,PublishDate,Img1,Content,AuthorContent,Specification,Sort,Enable")] Product product) {
			var data = _context.Product
						.Where(x => x.ID == id);
			Product update = data.FirstOrDefault();

			if (update == null) {
				return Json(new { result = "info", title = "查無此項目" });
			}

			if (ModelState.IsValid) {
				try {
					update.ProductCategoryID = product.ProductCategoryID;
					update.ISBN10 = product.ISBN10;
					update.ISBN13 = product.ISBN13;
					update.Name = product.Name;
					update.ListPrice = product.ListPrice;
					update.SalePrice = product.SalePrice;
					update.Stock = product.Stock;
					update.Author = product.Author;
					update.Translator = product.Translator;
					update.Publisher = product.Publisher;
					update.PublishDate = product.PublishDate;
					update.Content = product.Content;
					update.AuthorContent = product.AuthorContent;
					update.Specification = product.Specification;
					update.Sort = product.Sort;
					update.Enable = product.Enable;

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
		public async Task<JsonResult> EditProductSort(int id, [Bind("Sort")] int sort) {
			var data = _context.Product
						.Where(x => x.ID == id);
			Product update = data.FirstOrDefault();

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
		public async Task<JsonResult> DeleteProductByID(int id) {
			if (_context.Product == null) {
				return Json(new { result = "info", title = "查無此項目" });
			}
			var product = await _context.Product.FindAsync(id);
			if (product == null) {
				return Json(new { result = "info", title = "查無此項目" });
			}

			_context.Product.Remove(product);
			await _context.SaveChangesAsync();
			return Json(new { result = "success", title = "刪除成功" });
		}



	}
}
