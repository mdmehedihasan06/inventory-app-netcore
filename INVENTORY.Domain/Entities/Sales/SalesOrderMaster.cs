using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INVENTORY.Domain.Entities.Settings;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace INVENTORY.Domain.Entities.Sales
{
	[Index(nameof(OrderNo), IsUnique = true)]
	public class SalesOrderMaster : BaseEntity
	{        
        [ForeignKey("Customer")]
		public int CustomerId { get; set; }        
        [MaxLength(500), Column(TypeName = "nvarchar(500)")]
        public string? DeliveryAddress { get; set; }
        [MaxLength(500), Column(TypeName = "nvarchar(500)")]
        public string? DeliveryInstruction { get; set; }
        public int OrderNo { get; set; }
        [Column(TypeName = "Date")]
        public DateTime OrderDate { get; set; }
        public int? CreditDays { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalDiscount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? NetAmount { get; set; }        
        [MaxLength(100), Column(TypeName = "nvarchar(100)")]
        public string? ClientOrderNo { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? ClientOrderDate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? ClientOrderAmount { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? EstimatedDeliveryDate { get; set; }
        [MaxLength(500), Column(TypeName = "nvarchar(500)")]
        public string? Remarks { get; set; }

        public List<SalesOrderDetails>? SalesOrderDetails { get; set; }
        public List<SalesOrderCost>? SalesOrderCosts { get; set; }
    }
}
