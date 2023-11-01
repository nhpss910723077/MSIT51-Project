using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSIT51BT_ASP.Libraries;
using MSIT51BT_ASP.Models;
using System.Collections;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MSIT51BT_ASP.Controllers {
	partial class BackController {
		// 取得標題資料
		public JsonResult GetMemberPageData() {
			return Json(new {
				title = "會員管理",
				creatable = false,
				deletable = false,
			});
		}

		// 取得內容欄位資料
		public JsonResult GetMemberContentFieldData() {
			List<BackField> Data = new List<BackField>();
			Data.Add(new BackField {
				Type = BackFieldType.Input,
				FieldName = "Account",
				Name = "帳號",
				ColSize = 4,
				ReadOnly = true,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Input,
				FieldName = "Name",
				Name = "姓名",
				ColSize = 2,
				ReadOnly = true,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Input,
				FieldName = "NickName",
				Name = "暱稱",
				ColSize = 2,
				ReadOnly = true,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Input,
				FieldName = "Phone",
				Name = "電話",
				ColSize = 4,
				ReadOnly = true,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Input,
				FieldName = "County",
				Name = "縣市",
				ColSize = 4,
				ReadOnly = true,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Input,
				FieldName = "District",
				Name = "地區",
				ColSize = 4,
				ReadOnly = true,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Input,
				FieldName = "Zipcode",
				Name = "區碼",
				ColSize = 4,
				ReadOnly = true,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Input,
				FieldName = "Address",
				Name = "地址",
				ColSize = 6,
				ReadOnly = true,
				CutCol = true,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Select,
				FieldName = "Gender",
				Name = "性別",
				ColSize = 4,
				ReadOnly = true,
				RefKey = "DataValue",
				RefTable = "Config",
				RefField = "DataName",
			});

			Data.Add(new BackField {
				Type = BackFieldType.Datepicker,
				FieldName = "Birthday",
				Name = "生日",
				ColSize = 4,
				ReadOnly = true,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Input,
				FieldName = "ShoppingMoney",
				Name = "購物金",
				ColSize = 4,
				ReadOnly = true,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Switch,
				FieldName = "Enable",
				Name = "啟用",
				ColSize = 2,
			});

			Data.Add(new BackField {
				Type = BackFieldType.Switch,
				FieldName = "VerifyStatus",
				Name = "驗證狀態",
				ColSize = 2,
			});

			return Json(Data);
		}

		// 取得列表欄位資料
		public JsonResult GetMemberListFieldData() {
			List<BackField> Data = new List<BackField>();
			Data.Add(new BackField {
				Type = BackFieldType.Text,
				FieldName = "Account",
				Name = "帳號",
			});

			Data.Add(new BackField {
				Type = BackFieldType.Text,
				FieldName = "Name",
				Name = "姓名",
			});

			Data.Add(new BackField {
				Type = BackFieldType.Text,
				FieldName = "Phone",
				Name = "電話",
			});

			return Json(Data);
		}

		// 取得列表搜尋欄位資料
		public JsonResult GetMemberListSearchFieldData() {
			List<BackField> Data = new List<BackField>();

			Hashtable searchData = new Hashtable();

			return Json(new { searchFieldData = Data, searchData = searchData });
		}

		// 取得內容資料
		public JsonResult GetMemberContentData(int id) {
			Hashtable data = new Hashtable();

			//取得內容資料
			var item = _context.Member
						.Where(x => x.ID == id)
						.OrderByDescending(x => x.CreateTime)
						.Select(x => new {
							ID = x.ID,
							Account = x.Account,
							Name = x.Name,
							NickName = x.NickName,
							Phone = x.Phone,
							County = x.County,
							District = x.District,
							Zipcode = x.Zipcode,
							Address = x.Address,
							Gender = x.Gender,
							Birthday = x.Birthday,
							ShoppingMoney = x.ShoppingMoney,
							VerifyStatus = x.VerifyStatus,
							Enable = x.Enable,
						})
						.FirstOrDefault();
			data.Add("item", item);

			// 取得性別資料
			var config = _context.Config
						.Where(x => x.DataCategory == "Gender")
						.Select(x => x);
			data.Add("Config", config);

			return Json(data);
		}

		// 取得列表資料
		public JsonResult GetMemberListData() {
			int page = Convert.ToInt16(HttpContext.Request.Query["page"]); // 當前頁數
			if (page <= 0) page = 1;

			var data = _context.Member
					.OrderBy(x => x.Sort)
					.ThenByDescending(x => x.CreateTime)
					.Select(x => new {
						item = new {
							ID = x.ID,
							Account = x.Account,
							Name = x.Name,
							Phone = x.Phone,
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
		public JsonResult GetMemberPaginationData() {
			var totoRow = _context.Member
							.Select(x => x);

			var data = new {
				totalRow = totoRow.Count(),
				pageSize = pageSize
			};

			return Json(data);
		}

		// 編輯
		[HttpPost]
		//[ValidateAntiForgeryToken]
		public async Task<JsonResult> EditMemberContentData(int id, [Bind("VerifyStatus,Enable")] Member member) {
			var data = _context.Member
						.Where(x => x.ID == id);
			Member update = data.FirstOrDefault();

			if (update == null) {
				return Json(new { result = "info", title = "查無此項目" });
			}

			try {
				update.VerifyStatus = member.VerifyStatus;
				update.Enable = member.Enable;

				_context.Update(update);
				await _context.SaveChangesAsync();

				return Json(new { result = "success", title = "更新成功" });
			}
			catch (DbUpdateConcurrencyException) {
				return Json(new { result = "info", title = "更新失敗" });
			}
		}

		// 更新排序
		[HttpPost]
		//[ValidateAntiForgeryToken]
		public async Task<JsonResult> EditMemberSort(int id, [Bind("Sort")] int sort) {
			var data = _context.Member
						.Where(x => x.ID == id);
			Member update = data.FirstOrDefault();

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
		public async Task<JsonResult> DeleteMemberByID(int id) {
			if (_context.Member == null) {
				return Json(new { result = "info", title = "查無此項目" });
			}
			var member = await _context.Member.FindAsync(id);
			if (member == null) {
				return Json(new { result = "info", title = "查無此項目" });
			}

			_context.Member.Remove(member);
			await _context.SaveChangesAsync();
			return Json(new { result = "success", title = "刪除成功" });
		}



	}
}
