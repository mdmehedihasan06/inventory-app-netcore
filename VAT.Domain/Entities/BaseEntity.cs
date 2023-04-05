using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAT.Domain.Entities
{
	public class BaseEntity
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Column(TypeName = "DateTime")]
		public DateTime CreatedDate { get; set; }= DateTime.Now;
		[Required]
		public int CreatedBy { get; set; }
		[Column(TypeName = "DateTime")]
		public DateTime UpdatedDate { get; set; }
		public int UpdatedBy { get; set; }
		public bool IsActive { get; set; }
		public bool IsDeleted { get; set; }=false;
		public int IsDeletedBy { get; set; }
		[Column(TypeName = "DateTime")]
		public DateTime DeletedDate { get; set; }
		[Required]
		public string? TenantId { get; set; }
	}
}
