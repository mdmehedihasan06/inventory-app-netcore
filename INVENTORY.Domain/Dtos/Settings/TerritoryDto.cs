using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY.Domain.Dtos.Settings
{
    public class TerritoryDto
    {
        public string? TerritoryName { get; set; }
        public int TerritoryManagerId { get; set; }
        public int RegionId { get; set; }
    }
}
