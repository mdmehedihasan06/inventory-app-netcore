using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY.Domain.Entities.Settings
{
	public class ProductBrand : BaseEntity
	{
		[Required, Column(TypeName = "nvarchar(150)")]		
		public string? BrandName { get; set; }
		public List<Product>? Products { get; set; }
	}
}
