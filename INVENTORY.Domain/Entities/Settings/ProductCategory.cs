using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY.Domain.Entities.Settings
{
	public class ProductCategory : BaseEntity
	{
		[Required, Column(TypeName = "nvarchar(150)")]
		public string? CategoryName { get; set; }
		
		public List<ProductSubCategory>? ProductSubCategories { get; set; }
		public List<Product>? Products { get; set; }
	}
}
