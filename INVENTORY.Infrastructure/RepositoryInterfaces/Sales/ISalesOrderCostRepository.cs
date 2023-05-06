using INVENTORY.Domain.Entities.Sales;
using INVENTORY.Infrastructure.RepositoryInterfaces.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY.Infrastructure.RepositoryInterfaces.Sales
{
	public interface ISalesOrderCostRepository : IAsyncRepository<SalesOrderCost>
	{
	}
}
