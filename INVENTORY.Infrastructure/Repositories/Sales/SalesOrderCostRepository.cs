using INVENTORY.Domain.Entities.Sales;
using INVENTORY.Infrastructure.Context;
using INVENTORY.Infrastructure.Repositories.Generic;
using INVENTORY.Infrastructure.RepositoryInterfaces.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY.Infrastructure.Repositories.Sales
{
	public class SalesOrderCostRepository : RepositoryBase<SalesOrderCost>, ISalesOrderCostRepository
	{
		public SalesOrderCostRepository(AppDbContext context) : base(context)
		{
		}
	}
}
