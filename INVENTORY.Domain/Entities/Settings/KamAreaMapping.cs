using INVENTORY.Domain.Entities.Account;
using INVENTORY.Domain.Entities.Sales;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY.Domain.Entities.Settings
{
    public class KamAreaMapping : BaseEntity
    {
        [Required,ForeignKey("User")]        
        public int UserId { get; set; }
        //public User? User { get; set; }
        [Required, ForeignKey("Area")]
        public int AreaId { get; set; }
        //public Area? Area { get; set; }
    }
    public class KamAreaMappingConfiguration : BaseEntityConfiguration<KamAreaMapping>
    {
        protected override void ConfigureDerivedEntity(EntityTypeBuilder<KamAreaMapping> builder)
        {
            // SalesOrderDetails entity custome configuration            
        }
    }
}
