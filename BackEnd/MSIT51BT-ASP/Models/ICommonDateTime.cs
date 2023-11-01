using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSIT51BT_ASP.Models {
	public interface ICommonDateTime {
		DateTime UpdateTime { get; set; }
		DateTime CreateTime { get; set; }
	}
}
