using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSIT51BT_ASP.Models {
	public class Banner : ICommonDateTime {
        public int ID { get; set; }

        public string Category { get; set; }

        public string? Name { get; set; }

        public string? Link { get; set; }

        public string? Img1 { get; set; }

        public string? Img2 { get; set; }

        // ===== 共通 =====
        public int Sort { get; set; }

		public bool Enable { get; set; }

		public DateTime UpdateTime { get; set; }

		public DateTime CreateTime { get; set; }
	}
}
