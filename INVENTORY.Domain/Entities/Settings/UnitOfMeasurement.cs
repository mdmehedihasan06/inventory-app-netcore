using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INVENTORY.Domain.Entities.Sales;

namespace INVENTORY.Domain.Entities.Settings
{
    public class UnitOfMeasurement : BaseEntity
    {
        [Required, Column(TypeName = "nvarchar(50)")]
        public string? UnitName { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string? Description { get; set; }

        public List<SalesOrderDetails>? SalesOrderDetails { get; set; }
    }
}
