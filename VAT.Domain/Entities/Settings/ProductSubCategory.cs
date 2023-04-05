using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAT.Domain.Entities.Settings
{
	public class ProductSubCategory : BaseEntity
	{
		[MaxLength(150)]
		[Column(TypeName = "nvarchar(150)")]
		public string? SubCategoryName { get; set; }
		[ForeignKey("Category")]
		public int CategoryId { get; set; }
		public ProductCategory? ProductCategory { get; set; }
		public List<Product>? Products { get; set; }
	}
}
