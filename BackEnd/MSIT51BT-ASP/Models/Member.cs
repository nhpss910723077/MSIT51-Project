using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSIT51BT_ASP.Models {
	public class Member : ICommonDateTime {
        public int ID { get; set; }

        public string? FbMemberNumber { get; set; }

        public string? GoogleMemberNumber { get; set; }

        public string? LineMemberNumber { get; set; }

        public string Account { get; set; }

        public string? Password { get; set; }

        public string Name { get; set; }

        public string? NickName { get; set; }

        public string? Phone { get; set; }

        public string? County { get; set; }

        public string? District { get; set; }

        public int? Zipcode { get; set; }

		public string? Address { get; set; }

		public int Gender { get; set; }

		public DateTime? Birthday { get; set; }

		public string LineBindCode { get; set; }

        public int ShoppingMoney { get; set; }

        public string VerifyCode { get; set; }

        public bool VerifyStatus { get; set; }

        public bool PublicBookcase { get; set; }

        // ===== 共通 =====
        public int Sort { get; set; }

		public bool Enable { get; set; }

		public DateTime UpdateTime { get; set; }

		public DateTime CreateTime { get; set; }
    }
}
