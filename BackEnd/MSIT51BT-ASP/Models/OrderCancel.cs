using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSIT51BT_ASP.Models {
	public class OrderCancel : ICommonDateTime {
        public int ID { get; set; }

        public int OrderFormID { get; set; }

		public string Reason { get; set; }

		// ===== 共通 =====
		public int Sort { get; set; }

		public bool Enable { get; set; }

		public DateTime UpdateTime { get; set; }

		public DateTime CreateTime { get; set; }

        // ===== 相依 =====
        public OrderForm? OrderForm { get; set; }
    }
}
