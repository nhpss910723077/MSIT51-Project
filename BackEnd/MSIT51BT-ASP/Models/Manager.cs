using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSIT51BT_ASP.Models {
	public class Manager : ICommonDateTime {
        public int ID { get; set; }

        public string Account { get; set; }

        public string Password { get; set; }

        public string? Name { get; set; }

        // ===== 共通 =====
        public int Sort { get; set; }

		public bool Enable { get; set; }

		public DateTime UpdateTime { get; set; }

		public DateTime CreateTime { get; set; }
	}
}
