using INVENTORY.Domain.Entities.Account;
using INVENTORY.Domain.Entities.Settings;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY.Domain.Entities.Sales
{
    public class SalesOrderCost : BaseEntity
    {
        [Required, ForeignKey("SalesOrderMaster")]
        public int? SalesOrderMasterId { get; set; }
        [MaxLength(100), Column(TypeName = "nvarchar(100)")]
        public string? CostHead { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? CostAmount { get; set; }
    }
    public class SalesOrderCostConfiguration : BaseEntityConfiguration<SalesOrderCost>
    {
        protected override void ConfigureDerivedEntity(EntityTypeBuilder<SalesOrderCost> builder)
        {
            // SalesOrderDetails entity custome configuration
        }
    }
}
