using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSIT51BT_ASP.Models {
	public class OrderForm : ICommonDateTime {
        public int ID { get; set; }

        public string Number { get; set; }

        public int MemberID { get; set; }

        public int ShippingFee { get; set; }

        public int SubTotal { get; set; }

        public int Total { get; set; }

        public int PaymentType { get; set; }

        public int ShippingType { get; set; }

        public string? ReceiveName { get; set; }

        public string? ReceiveEmail { get; set; }

        public string? ReceivePhone { get; set; }

        public string? ReceiveCounty { get; set; }

        public string? ReceiveDistrict { get; set; }

        public int? ReceiveZipcode { get; set; }

        public string? ReceiveAddress { get; set; }

        public string? Remark { get; set; }

        public string? CVSID { get; set; }

        public string? CVSStoreName { get; set; }

        public string? CVSStoreAddress { get; set; }

        public string? ATMBankCode { get; set; }

        public string? ATMAccount { get; set; }

        public DateTime? ExpireDate { get; set; }

        public string? ShippingNumber { get; set; }

        public string? ShippingCVSPaymentNo { get; set; }

        public DateTime? ShippingDate { get; set; }

        public DateTime? PaymentTime { get; set; }

        public bool PaymentStatus { get; set; }

        public int Status { get; set; }

        // ===== 共通 =====
        public int Sort { get; set; }

		public bool Enable { get; set; }

		public DateTime UpdateTime { get; set; }

		public DateTime CreateTime { get; set; }

        // ===== 相依 =====
        public Member? Member { get; set; }
    }
}
