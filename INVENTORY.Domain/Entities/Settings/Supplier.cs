using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY.Domain.Entities.Settings
{
	public class Supplier : BaseEntity
	{
		[Required,Column(TypeName = "nvarchar(150)")]
		public string? SupplierName { get; set; }
		[MaxLength(500), Column(TypeName = "nvarchar(500)")]
		public string? Address { get; set; }
		[MaxLength(500), Column(TypeName = "nvarchar(500)")]
		public string? BillingAddress { get; set; }
		[MaxLength(500), Column(TypeName = "nvarchar(500)")]
		public string? DeliveryAddress { get; set; }
		[MaxLength(50), Column(TypeName = "nvarchar(50)")]
		public string? BinNo { get; set; }
		[MaxLength(50), Column(TypeName = "nvarchar(50)")]
		public string? TinNo { get; set; }
		[MaxLength(50), Column(TypeName = "nvarchar(50)")]
		public string? NidNo { get; set; }
		[MaxLength(150), Column(TypeName = "nvarchar(150)")]
		public string? ContactPerson { get; set; }
		[MaxLength(150), Column(TypeName = "nvarchar(150)")]
		public string? CpDesignation { get; set; }
		[MaxLength(150), Column(TypeName = "nvarchar(150)")]
		public string? CpDepartment { get; set; }
		[MaxLength(100), Column(TypeName = "nvarchar(100)")]
		public string? CpMobile { get; set; }
		[MaxLength(100), Column(TypeName = "nvarchar(100)")]
		public string? CpEmail { get; set; }
		[Column(TypeName = "Date")]
		public DateTime? OpeningDate { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public decimal? OpeningAmount { get; set; }
		[Column(TypeName = "nvarchar(50)")]
		public string? SupplierType { get; set; }
	}
}
