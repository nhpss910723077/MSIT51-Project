using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSIT51BT_ASP.Models {
	public class Product : ICommonDateTime {
		public int ID { get; set; }

		public int ProductCategoryID { get; set; }

        public string? ISBN10 { get; set; }

        public string? ISBN13 { get; set; }

        public string? Name { get; set; }

        public int ListPrice { get; set; }

        public int SalePrice { get; set; }

		public int Stock { get; set; }

		public int Sold { get; set; }

		public string? Author { get; set; }

        public string? Translator { get; set; }

        public string? Publisher { get; set; }

        public DateTime PublishDate { get; set; }

        public string? Img1 { get; set; }

        public string? Content { get; set; }

        public string? AuthorContent { get; set; }

        public string? Specification { get; set; }

        // ===== 共通 =====
        public int Sort { get; set; }

        public bool Enable { get; set; }

        public DateTime UpdateTime { get; set; }

        public DateTime CreateTime { get; set; }

        // ===== 相依 =====
        public ProductCategory? ProductCategory { get; set; }
    }

}
