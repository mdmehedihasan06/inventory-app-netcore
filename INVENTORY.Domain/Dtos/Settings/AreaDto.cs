using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY.Domain.Dtos.Settings
{
    public class AreaDto
    {
        public string? AreaName { get; set; }
        public int AreaManagerId { get; set; }
        public int TerritoryId { get; set; }
    }
}
