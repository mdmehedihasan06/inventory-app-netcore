using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY.Domain.Dtos.Settings
{
    public class RegionDto
    {
        public string? RegionName { get; set; }
        public int RegionalManagerId { get; set; }
    }
}
