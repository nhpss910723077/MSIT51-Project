using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSIT51BT_ASP.Models {
	public class UsedSale : ICommonDateTime {
        public int ID { get; set; }

        public int MemberID { get; set; }

        public int ProductID { get; set; }

        public int SalePrice { get; set; }

        public string WithdrawType { get; set; }

        public string? RemitAccount { get; set; }

        public int BookStatus { get; set; }

        public string? Img1 { get; set; }

        public string? Img2 { get; set; }

        public string? Img3 { get; set; }

        public string? Img4 { get; set; }

        public string? Img5 { get; set; }

        public int VerifyStatus { get; set; }

        public DateTime VerifyDateTime { get; set; }

        public bool Sold { get; set; }

        // ===== 共通 =====
		public bool Enable { get; set; }

		public DateTime UpdateTime { get; set; }

		public DateTime CreateTime { get; set; }

        // ===== 相依 =====
        public Member? Member { get; set; }

        public Product? Product { get; set; }
    }
}
