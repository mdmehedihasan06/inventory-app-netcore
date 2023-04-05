using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAT.Domain.Entities.Account;

namespace VAT.Domain.Entities.Settings
{
	public class Region : BaseEntity
	{
		[Required]
		[MaxLength(150)]
		[Column(TypeName = "nvarchar(150)")]
		public string? RegionName { get; set; }
		public List<Territory>? Territories { get; set; }
		[Required]
		[ForeignKey("User")]
		public int RegionalManagerId { get; set; }
		public User? RegionalManager { get; set; }
	}
}
