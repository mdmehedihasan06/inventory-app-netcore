﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY.Domain.Entities.Settings
{
	public class ProductModel : BaseEntity
	{
		[Required,MaxLength(150), Column(TypeName = "nvarchar(100)")]
		public string? ModelName { get; set; }
		public List<Product>? Products { get; set;}
	}
}
