using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSIT51BT_ASP.Models {
	public class SearchKeyword {
        public int ID { get; set; }

        public string Name { get; set; }

        public int SearchTime { get; set; }
    }
}
