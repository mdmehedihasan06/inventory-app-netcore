using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY.Domain.Dtos.Settings
{
	public class UnitOfMeasurementDto
	{
		public string? UnitName { get; set; }
		public string? Description { get; set; }
	}
}
