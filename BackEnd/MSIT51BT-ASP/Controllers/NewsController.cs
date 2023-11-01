using Microsoft.AspNetCore.Mvc;
using MSIT51BT_ASP.Libraries;

namespace MSIT51BT_ASP.Controllers {
    public class NewsController : Controller {
        private readonly Models.SqlContext _context;

        public NewsController(Models.SqlContext context)
        {
            _context = context;
        }

        public JsonResult AnnData()
        {
            var q = _context.News
                .Where(x => x.NewsCategoryID == 2)
                .Select(x => new { pic = x.Img1 != null ? MyHelper.GetFilePath(HttpContext, x.Img1) : "", title = x.Name, text = x.StartDate.ToString().Substring(0, 10), newsID = x.ID });

            return Json(q.ToList());
        }

        
        public JsonResult EventData()
        {
            var q = _context.News
                .Where(x => x.NewsCategoryID == 1)
                .Where(x => x.Enable == true)
                //.Where(x => x.UpdateTime.ToString().Substring(0, 10) == "2023-10-13")
                .Select(x => new { pic= x.Img1 != null ? MyHelper.GetFilePath(HttpContext, x.Img1) : "", title = x.Name, 
                                   start = x.StartDate.ToString().Substring(0, 10), end=x.EndDate.ToString().Substring(0, 10),
                newsID=x.ID});

            return Json(q.ToList());
        }

        
       
        public JsonResult NewsContent(int newsID)
        {
            var q = _context.News
                .Where(x => x.ID == newsID)
                .Where(x => x.Enable == true)
                .Select(x =>x )
                .SingleOrDefault();

            if (q != null && q.NewsCategoryID==1)
            {
                return Json(new
                {
                    pic = q.Img1 != null ? MyHelper.GetFilePath(HttpContext, q.Img1) : "",
                    title = q.Name,
                    start = ((DateTime)q.StartDate).ToString("yyyy-MM-dd"),
                    end = ((DateTime)q.EndDate).ToString("yyyy-MM-dd"),
                    content = q.Content
                });
            }
            else
            {
                return Json(new
                {
                    pic = q.Img1 != null ? MyHelper.GetFilePath(HttpContext, q.Img1) : "",
                    title = q.Name,
                    text = ((DateTime)q.StartDate).ToString("yyyy-MM-dd"),
                    content = q.Content
                });
            }

           
        }

    }
}
