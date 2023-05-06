﻿using INVENTORY.Domain.Entities.Settings;
using INVENTORY.Infrastructure.Context;
using INVENTORY.Infrastructure.Repositories.Generic;
using INVENTORY.Infrastructure.RepositoryInterfaces.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY.Infrastructure.Repositories.Settings
{
	public class ProductBrandRepository : RepositoryBase<ProductBrand>, IProductBrandRepository
	{
		public ProductBrandRepository(AppDbContext context) : base(context)
		{
		}
	}
}
