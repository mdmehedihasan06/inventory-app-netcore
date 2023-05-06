using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY.Domain.Dtos.Settings
{
    public class ProductDto
    {
        public string? ProductCode { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public decimal? DefaultPrice { get; set; }
        public int? CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public int? BrandId { get; set; }
        public int? ModelId { get; set; }
        public bool? HideFromStock { get; set; }
        public bool? ShowDescriptionInPurchase { get; set; }
        public bool? ShowDescriptionInSales { get; set; }
    }
}
