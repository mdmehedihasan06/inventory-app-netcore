using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INVENTORY.Domain.Entities.Account;

namespace INVENTORY.Domain.Entities.Settings
{
	public class Area : BaseEntity
	{
		[Required,MaxLength(150),Column(TypeName = "nvarchar(150)")]
		public string? AreaName { get; set; }
		[Required,ForeignKey("User")]
		public int AreaManagerId { get; set; }
		//public User? AreaManager { get; set; }
		[Required, ForeignKey("Territory")]
		public int TerritoryId { get; set; }
		//public Territory? Territory { get; set; }

        public List<KamAreaMapping>? KamAreaMappings { get; set; }
    }
}
