using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSIT51BT_ASP.Models {
	public class ShoppingMoneyRecord {
        public int ID { get; set; }

        public int MemberID { get; set; }

        public int Money { get; set; }

        public string Content { get; set; }

        // ===== 共通 =====
        public DateTime UpdateTime { get; set; }

        public DateTime CreateTime { get; set; }

        // ===== 相依 =====
        public Member? Member { get; set; }
    }
}
