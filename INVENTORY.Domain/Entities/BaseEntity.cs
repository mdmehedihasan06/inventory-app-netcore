using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY.Domain.Entities
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime? CreatedDate { get; set; } = DateTime.Now;        
        public int? CreatedBy { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsActive { get; set; } = false;
        public bool? IsDeleted { get; set; } = false;        
        public int? DeletedBy { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime? DeletedDate { get; set; }
        [Required]
        public string? TenantId { get; set; }
		[Column(TypeName = "nvarchar(300)")]
		public string? DeviceInfo { get; set; }
    }

    public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Ignore(b => b.CreatedBy);
            builder.Ignore(b => b.UpdatedDate);
            builder.Ignore(b => b.UpdatedBy);
            builder.Ignore(b => b.IsActive);
            builder.Ignore(b => b.IsDeleted);
            builder.Ignore(b => b.DeletedBy);
            builder.Ignore(b => b.DeletedDate);
            builder.Ignore(b => b.TenantId);
            ConfigureDerivedEntity(builder);
        }

        protected abstract void ConfigureDerivedEntity(EntityTypeBuilder<T> builder);
    }
}
