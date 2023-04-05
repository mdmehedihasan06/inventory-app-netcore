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
	public class Customer : BaseEntity
	{		
		[Required, MaxLength(150), Column(TypeName = "nvarchar(150)")]
		public string? CustomerName { get; set; }
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
		public string? OpeningDate { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public string? OpeningAmount { get; set; }
		[Column(TypeName = "nvarchar(50)")]
		public string? CustomerType { get; set; }
		[ForeignKey("User")]
		public int KeyAccountManagerId { get; set; }
		public User? KeyAccountManager { get; set; }
	}
}
