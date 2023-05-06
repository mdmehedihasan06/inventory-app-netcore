using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY.Domain.Dtos.Settings
{
	public class KamAreaMappingDto
	{
		public int UserId { get; set; }
		public int AreaId { get; set; }
	}
}
