using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSIT51BT_ASP.Models {
	public class LineBind : ICommonDateTime {
		public int ID { get; set; }

        public string LineID { get; set; }

        public string LineCode { get; set; }

		// ===== 共通 =====
		public DateTime UpdateTime { get; set; }

		public DateTime CreateTime { get; set; }
	}
}
