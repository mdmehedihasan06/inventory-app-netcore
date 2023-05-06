using INVENTORY.Domain.Entities.Sales;
using INVENTORY.Domain.Entities.Settings;
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
	public class SalesOrderMasterRepository : RepositoryBase<SalesOrderMaster>, ISalesOrderMasterRepository
	{
		public SalesOrderMasterRepository(AppDbContext context) : base(context)
		{
		}
	}
}
