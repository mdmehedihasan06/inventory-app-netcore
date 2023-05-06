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
    public class SalesOrderDetails : BaseEntity
    {
        [Required, ForeignKey("SalesOrderMaster")]
        public int? SalesOrderMasterId { get; set; }
        [Required, ForeignKey("Product")]
        public int ProductId { get; set; }
        [MaxLength(int.MaxValue), Column(TypeName = "nvarchar(max)")]
        public string? ProductDescription { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Quantity { get; set; }
        [ForeignKey("UnitOfMeasurement")]
        public int? UnitId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? UnitPrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalPrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Discount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? VatAmount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TaxAmount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? NetAmount { get; set; }
        public bool? IsFree { get; set; }
        public int? WarrantyValue { get; set; }
        [MaxLength(10), Column(TypeName = "nvarchar(10)")]
        public string? WarrantyValueType { get; set; }
    }

    public class SalesOrderDetailsConfiguration : BaseEntityConfiguration<SalesOrderDetails>
    {
        protected override void ConfigureDerivedEntity(EntityTypeBuilder<SalesOrderDetails> builder)
        {
            // SalesOrderDetails entity custome configuration
        }
    }
}
