using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INVENTORY.Domain.Entities.Sales
{
	public class SalesOrderPayment:BaseEntity
	{
		[Required, ForeignKey("SalesOrderMaster")]
		public int? SalesOrderMasterId { get; set; }
		[MaxLength(100), Column(TypeName = "nvarchar(100)")]
		public string? PaymentHead { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public decimal? PaymentAmount { get; set; }
	}

	public class SalesOrderPaymentConfiguration : BaseEntityConfiguration<SalesOrderPayment>
	{
		protected override void ConfigureDerivedEntity(EntityTypeBuilder<SalesOrderPayment> builder)
		{
			// SalesOrderDetails entity custome configuration
		}
	}
}
