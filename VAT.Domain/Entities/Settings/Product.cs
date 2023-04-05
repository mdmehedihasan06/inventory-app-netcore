using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAT.Domain.Entities.Settings
{
	public class Product : BaseEntity
	{
		[MaxLength(50)]
		[Column(TypeName = "nvarchar(50)")]		
		public string? ProductCode { get; set; }
		[Required]
		[MaxLength(250)]
		[Column(TypeName = "nvarchar(250)")]
		public string? ProductName { get; set; }		
		public string? Description { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public decimal DefaultPrice { get; set; }
		[ForeignKey("ProductCategory")]
		public int CategoryId { get; set; }
		public ProductCategory? ProductCategories { get; set; }
		[ForeignKey("ProductSubCategory")]
		public int SubCategoryId { get; set; }
		public ProductSubCategory? ProductSubCategories { get; set; }
		[ForeignKey("ProductBrand")]
		public int BrandId { get; set; }
		public ProductBrand? ProductBrand { get; set; }
		[ForeignKey("ProductModel")]
		public int ModelId { get; set; }
		public ProductModel? ProductModel { get; set; }
	}
}
