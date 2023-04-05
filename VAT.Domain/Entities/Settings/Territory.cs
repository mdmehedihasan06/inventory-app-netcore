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
	public class Territory : BaseEntity
	{
		[Required]
		[MaxLength(150)]
		[Column(TypeName = "nvarchar(150)")]
		public string? TerritoryName { get; set; }
		[Required]
		[ForeignKey("User")]
		public int TerritoryManagerId { get; set; }
		public User? TerritoryManager { get; set; }
		[Required]
		[ForeignKey("Region")]
		public int RegionId { get; set; }
		public Region? Region { get; set; }
		public List<Area>? Areas { get; set; }
	}
}
