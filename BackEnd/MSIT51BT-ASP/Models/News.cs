using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSIT51BT_ASP.Models {
	public class News : ICommonDateTime {
		public int ID { get; set; }

		public int NewsCategoryID { get; set; }

		public string? Name { get; set; }

        public string? Img1 { get; set; }

        public string? Content { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        // ===== 共通 =====
        public int Sort { get; set; }

        public bool Enable { get; set; }

        public DateTime UpdateTime { get; set; }

        public DateTime CreateTime { get; set; }

        // ===== 相依 =====
        public NewsCategory? NewsCategory { get; set; }
    }

}
