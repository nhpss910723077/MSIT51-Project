using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSIT51BT_ASP.Models {
	public class UsedSeek : ICommonDateTime {
        public int ID { get; set; }

        public int MemberID { get; set; }

        public int ProductID { get; set; }

        public int SeekPrice { get; set; }

        // ===== 共通 =====
		public bool Enable { get; set; }

		public DateTime UpdateTime { get; set; }

		public DateTime CreateTime { get; set; }

        // ===== 相依 =====
        public Member? Member { get; set; }

        public Product? Product { get; set; }
    }
}
