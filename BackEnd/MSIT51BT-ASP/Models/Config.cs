using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSIT51BT_ASP.Models {
	public class Config : ICommonDateTime {
        public int ID { get; set; }

        public string DataCategory { get; set; }

        public int DataValue { get; set; }

        public string? DataName { get; set; }

        // ===== 共通 =====
        public int Sort { get; set; }

		public bool Enable { get; set; }

		public DateTime UpdateTime { get; set; }

		public DateTime CreateTime { get; set; }
	}
}
