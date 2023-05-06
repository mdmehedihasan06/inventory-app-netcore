using INVENTORY.Domain.Entities.Sales;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY.Domain.Entities.Settings
{
	public class Product : BaseEntity
	{
		[MaxLength(50),Column(TypeName = "nvarchar(50)")]
		public string? ProductCode { get; set; }
		[Required, Column(TypeName = "nvarchar(250)")]
		public string? ProductName { get; set; }		
		public string? Description { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public decimal? DefaultPrice { get; set; }
		[ForeignKey("ProductCategory")]
		public int? CategoryId { get; set; }
		[ForeignKey("ProductSubCategory")]
		public int? SubCategoryId { get; set; }
		[ForeignKey("ProductBrand")]
		public int? BrandId { get; set; }
		[ForeignKey("ProductModel")]
		public int? ModelId { get; set; }
		public bool? HideFromStock { get; set; }
        public bool? ShowDescriptionInPurchase { get; set; }
        public bool? ShowDescriptionInSales { get; set; }

		public List<SalesOrderDetails>? SalesOrderDetails { get;set; }

    }
}
