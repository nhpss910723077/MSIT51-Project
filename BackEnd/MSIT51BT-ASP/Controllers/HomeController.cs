using Microsoft.AspNetCore.Mvc;
using MSIT51BT_ASP.Libraries;
using MSIT51BT_ASP.Models;

namespace MSIT51BT_ASP.Controllers {

    public class HomeController : Controller {
        private readonly Models.SqlContext _context;

        public HomeController(Models.SqlContext context) {
            _context = context;
        }
        public JsonResult GetBannerAtHome() {
            var data = _context.Banner
                .Where(x => x.Enable == true)
                .Where(x => x.Category == "home")
                .Select(x => new {
                    x.Img1,
                    x.Link
                });
            return Json(data);
        }
        public JsonResult GetSubHeadAtHome() {
            var data = _context.Banner
                .Where(x => x.Enable == true)
                .Where(x => x.Category == "page")
                .Select(x => new {
                    x.Img1,
                    x.Link
                });
            return Json(data);
        }
        public JsonResult GetNewBookAtHome() {
            var data = _context.Product
                .Where(x => x.Enable == true)
                .Select(x => new {
                    x.Name,
                    Img1 = x.Img1 != null ? MyHelper.GetFilePath(HttpContext, x.Img1) : "",
                    //Img1 = x.Img1 != null ? ("/" + x.Img1) : "",
                    x.PublishDate,
                    pID = x.ID,
                    cID = x.ProductCategoryID
                })
                .OrderByDescending(x => x.PublishDate)
                .Take(8);
            return Json(data);
        }
        public JsonResult GetKeyWordAtHome() {
            var data = _context.SearchKeyword
                .Select(x => new { x.Name, x.SearchTime })
                .OrderByDescending(x => x.SearchTime)
                .Take(12);
            return Json(data);
        }
        public JsonResult GetSuggestBookAtHome() {
            var data = _context.Product
                .Where(x => x.Enable == true)
                .Select(x => new {
                    x.Name,
                    Img1 = x.Img1 != null ? MyHelper.GetFilePath(HttpContext, x.Img1) : "",
                    //Img1 = x.Img1 != null ? ("/" + x.Img1) : "",
                    pID = x.ID,
                    cID = x.ProductCategoryID
                })
                .OrderBy(x => Guid.NewGuid())
                .Take(8);
            return Json(data);
        }
        public JsonResult GetUserSeekAtHome() {
            var data = _context.Product.Join(
                _context.UsedSeek,
                p => p.ID,
                u => u.ProductID,
                (p, u) => new {
                    p.Name,
                    Img1 = p.Img1 != null ? MyHelper.GetFilePath(HttpContext, p.Img1) : "",
                    //Img1 = x.Img1 != null ? ("/" + x.Img1) : "",
                    cID = p.ProductCategoryID,
                    pID = p.ID,
                    pEnable = p.Enable,
                    uEnable = u.Enable
                })

                .Where(x => x.pEnable == true)
                .Where(x => x.uEnable == true)
                .GroupBy(x => x.pID)
                .Select(x => new {
                    ProductID = x.Key,
                    Count = x.Count(),
                    Name = x.First().Name,
                    Img1 = x.First().Img1,
                    x.First().pID,
                    x.First().cID,
                })
                .OrderByDescending(x => x.Count)
                .Distinct()
                .Take(8);
            return Json(data);
        }
        public JsonResult GetNewsAtHome() {
            var data = _context.News
                .Where(x => x.NewsCategoryID == 1)
                .Where(x => x.Enable == true)
                .Select(x => new {
                    Img1 = x.Img1 != null ? MyHelper.GetFilePath(HttpContext, x.Img1) : "",
                    //Img1 = x.Img1 != null ? ("/" + x.Img1) : "",
                    x.ID
                });
            return Json(data);
        }
    }
}
