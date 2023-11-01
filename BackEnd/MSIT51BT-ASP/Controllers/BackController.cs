using Microsoft.AspNetCore.Mvc;

namespace MSIT51BT_ASP.Controllers {
	public partial class BackController : Controller {
		private readonly Models.SqlContext _context;
		private readonly IWebHostEnvironment _env;
        private string uploadPath = "uploads";
        private int pageSize = 20; // 列表一頁幾筆


        public BackController(Models.SqlContext context, IWebHostEnvironment env) {
			_context = context;
			_env = env;
		}

	}
}
