using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAT.Domain.Entities.Settings;

namespace VAT.Domain.Entities.Account
{
	[Table("Users")]
	public class User: BaseEntity
	{
		[MaxLength(50)]
		[Required]
        public string? UserId { get; set; }
		[Required]
		[MaxLength(100)]
		public string? Password { get; set; }
		[MaxLength(100)]
		public string? FirstName { get; set; }
		[MaxLength(100)]
		public string? LastName { get; set; }
		[MaxLength(100)]
		public string? Email { get; set; }

		public List<Region>? Regions { get; set; }
		public List<Territory>? Territories { get; set; }
		public List<Area>? Areas { get; set; }
		public List<Customer>? Customers { get; set; }
	}
}
