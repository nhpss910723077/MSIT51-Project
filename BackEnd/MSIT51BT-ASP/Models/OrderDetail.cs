using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSIT51BT_ASP.Models {
	public class OrderDetail {
        public int ID { get; set; }

		public string Type { get; set; }

		public int OrderFormID { get; set; }

        public int ProductID { get; set; }

        public string ProductName { get; set; }

		public int? UsedID { get; set; }

		public int Quantity { get; set; }

        public int SalePrice { get; set; }

        // ===== 相依 =====
        public OrderForm? OrderForm { get; set; }

        public Product? Product { get; set; }

		public UsedSale? UsedSale { get; set; }
	}
}
