using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSIT51BT_ASP.Models;
using MSIT51BT_ASP.Libraries;
using System.Linq;
using System.Security.Cryptography;

namespace MSIT51BT_ASP.Controllers {
    public class ProductController : Controller {
        private readonly Models.SqlContext _context;

        public ProductController(Models.SqlContext context) {
            _context = context;
        }

        public JsonResult GetCategory() {
            var data = _context.ProductCategory
                .Where(x => x.Enable == true)
                .Select(x => new { x.Name });

            return Json(data);
        }

        public JsonResult GetUserSaleInCategory() {
            var data = _context.UsedSale
                .Join(
                _context.Product,
                u => u.ProductID,
                p => p.ID,
                (u, p) => new {
                    u.Sold,
                    u.Enable,
                    p.Name,
                    p.Img1,
                    p.SalePrice,
                    pID = p.ID,
                    cID = p.ProductCategoryID,
                }
                )
                .Where(x => x.Sold == false)
                .Where(x => x.Enable == true)
                .Select(x => new {
                    x.Name,
                    Img1 = x.Img1 != null ? MyHelper.GetFilePath(HttpContext, x.Img1) : "",
                    //Img1 = x.Img1 != null ? ("/" + x.Img1) : "",
                    x.pID,
                    x.cID,
                    x.SalePrice
                })
                .Distinct();

            return Json(data);
        }

        public JsonResult GetDefaultProductInCategory() {
            var data = _context.Product
                .Where(x => x.Enable == true)
                .OrderByDescending(x => x.Sold)
                .Select(x => new {
                    x.SalePrice,
                    x.Name,
                    Img1 = x.Img1 != null ? MyHelper.GetFilePath(HttpContext, x.Img1) : "",
                    //Img1 = x.Img1 != null ? ("/" + x.Img1) : "",
                    x.Stock,
                    pID = x.ID,
                    cID = x.ProductCategoryID,
                    CategoryName = x.ProductCategory.Name,
                });
            return Json(data);
        }

        public JsonResult GetProductInCategory(int id) {
            var data = _context.Product
                .Join(
                _context.ProductCategory,
                p => p.ProductCategoryID,
                c => c.ID,
                (p, c) => new {
                    pID = p.ID,
                    pEnable = p.Enable,
                    p.Stock,
                    p.Name,
                    p.Img1,
                    p.SalePrice,
                    cID = c.ID,
                    CategoryName = c.Name
                })
                .Where(x => x.cID == id)
                .Where(x => x.pEnable == true)
                .Select(x => new {
                    x.Stock,
                    x.Name,
                    Img1 = x.Img1 != null ? MyHelper.GetFilePath(HttpContext, x.Img1) : "",
                    //Img1 = x.Img1 != null ? ("/" + x.Img1) : "",
                    x.pID,
                    x.cID,
                    x.CategoryName,
                    x.SalePrice
                });

            return Json(data);
        }

        [HttpPost]
        public async Task<JsonResult> PostSearchInCategory() {
            string search = HttpContext.Request.Form["search"];
            var data = _context.SearchKeyword
                .Where(x => x.Name == search);
            if (data.Count() >= 1) {
                try {
                    SearchKeyword update = data.FirstOrDefault()!;
                    update.Name = search;
                    update.SearchTime = update.SearchTime + 1;
                    _context.SearchKeyword.Update(update);
                    await _context.SaveChangesAsync();
                    return Json(data);
                }
                catch (DbUpdateConcurrencyException) {
                    return Json(new { result = "info", title = "更新失敗" });
                }
            }
            else {
                if (ModelState.IsValid) {
                    SearchKeyword searchKeyword = new SearchKeyword();
                    searchKeyword.Name = search;
                    searchKeyword.SearchTime = 1;
                    _context.SearchKeyword.Add(searchKeyword);
                    await _context.SaveChangesAsync();

                    return Json(new { result = "success", title = "送出成功" });
                }

                var ModelStateErrors = ModelState.Where(x => x.Value.Errors.Count > 0)
                .ToDictionary(k => k.Key, k => k.Value.Errors.Select(e => e.ErrorMessage).ToArray());

                return Json(new { result = "error", title = "發生錯誤", data = ModelStateErrors });
            }


        }

        public JsonResult GetSearchInCategory() {
            string search = HttpContext.Request.Query["search"];

            var data = _context.Product
                .Where(x => x.Enable == true && x.Name.Contains(search))
                .Select(x => new {
                    x.Stock,
                    x.Name,
                    Img1 = x.Img1 != null ? MyHelper.GetFilePath(HttpContext, x.Img1) : "",
                    //Img1 = x.Img1 != null ? ("/" + x.Img1) : "",
                    pID = x.ID,
                    cID = x.ProductCategoryID,
                    x.SalePrice
                });
            return Json(data);
        }

        public JsonResult GetProductInProduct(int id) {
            var data = _context.Product
                .Where(x => x.ID == id)
                .Where(x => x.Enable == true)
                .Select(x => new {
                    pID = x.ID,
                    x.Name,
                    Img1 = x.Img1 != null ? MyHelper.GetFilePath(HttpContext, x.Img1) : "",
                    //Img1 = x.Img1 != null ? ("/" + x.Img1) : "",
                    x.SalePrice,
                    x.ListPrice,
                    x.Author,
                    x.PublishDate,
                    x.Publisher,
                    x.Translator,
                    x.AuthorContent,
                    x.Content,
                    x.Specification,
                    x.ProductCategoryID,
                    x.Stock,
                    x.ISBN13,
                    CategoryName = x.ProductCategory.Name
                }).SingleOrDefault();

            return Json(data);
        }

        public JsonResult GetCommentInProduct(int id) {
            var data = _context.Bookcase
                .Where(x => x.ProductID == id)
                .Where(x=>x.Review != null || x.Score != null)
                .Where(x => x.Enable == true)
                .Select(x => new {
                    x.Member!.NickName,
                    x.Review,
                    x.ReviewTitle,
                    x.Score
                });
            return Json(data);
        }

        public JsonResult GetUsedSaleInProduct(int id) {
            var data = _context.UsedSale
                .Join(
                _context.Config,
                u => u.BookStatus,
                c => c.DataValue,
                (u, c) => new {
                    uID = u.ID,
                    BookStatusID = u.BookStatus,
                    NickName = u.Member!.NickName,
                    pID = u.ProductID,
                    u.SalePrice,
                    u.Img1,
                    u.Img2,
                    u.Img3,
                    u.Sold,
                    Date = u.CreateTime.Date,
                    u.Enable,
                    BookStatus = c.DataName,
                    c.DataCategory
                })
                .Where(x => x.DataCategory == "BookStatus")
                .Where(x => x.pID == id)
                .Where(x => x.Sold == false)
                .Where(x => x.Enable == true)
                .OrderBy(x => x.SalePrice)
                .Select(x => new {
                    x.uID,
                    x.pID,
                    x.BookStatusID,
                    x.NickName,
                    x.SalePrice,
                    Img1 = x.Img1 != null ? MyHelper.GetFilePath(HttpContext, x.Img1) : "",
                    //Img1 = x.Img1 != null ? ("/" + x.Img1) : "",
                    Img2 = x.Img2 != null ? MyHelper.GetFilePath(HttpContext, x.Img2) : "",
                    //Img2 = x.Img2 != null ? ("/" + x.Img2) : "",
                    Img3 = x.Img3 != null ? MyHelper.GetFilePath(HttpContext, x.Img3) : "",
                    //Img3 = x.Img3 != null ? ("/" + x.Img3) : "",
                    x.BookStatus,
                    x.Date
                });
            return Json(data);
        }

        public JsonResult GetSuggestInProduct(int id, [Bind("pID")] int pID) {
            var data = _context.Product
                .Where(x => x.ID != pID) // 希望去除本頁產品
                .Where(x => x.ProductCategoryID == id)
                .Where(x => x.Enable == true)
                .OrderByDescending(x => x.Sold)
                .Select(x => new {
                    x.Name,
                    Img1 = x.Img1 != null ? MyHelper.GetFilePath(HttpContext, x.Img1) : "",
                    //Img1 = x.Img1 != null ? ("/" + x.Img1) : "",
                    pID = x.ID,
                    cID = x.ProductCategoryID,
                });
            return Json(data);
        }

        public JsonResult SaleAverageInProduct(int id) {

            var data = _context.UsedSale
                .Where(x => x.ProductID == id)
                .Where(x => x.Enable == true)
                .Select(x => new {
                    x.SalePrice
                });

            var dataInMemory = data.ToList();
            double averageSalePrice = dataInMemory.Select(x => x.SalePrice).DefaultIfEmpty(0).Average();

            int intAverageSalePrice = (int)Math.Round(averageSalePrice);

            return Json(intAverageSalePrice);
        }

        public JsonResult SeekAverageInProduct(int id) {

            var data = _context.UsedSeek
                .Where(x => x.ProductID == id)
                .Where(x => x.Enable == true)
                .Select(x => new {
                    x.SeekPrice
                });

            var dataInMemory = data.ToList();
            double averageSeekPrice = dataInMemory.Select(x => x.SeekPrice).DefaultIfEmpty(0).Average();

            int intAverageSeekPrice = (int)Math.Round(averageSeekPrice);

            return Json(intAverageSeekPrice);
        }
    }
}

