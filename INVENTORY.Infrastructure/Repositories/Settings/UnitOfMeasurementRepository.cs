using INVENTORY.Domain.Entities.Settings;
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
	public class UnitOfMeasurementRepository : RepositoryBase<UnitOfMeasurement>, IUnitOfMeasurementRepository
	{
		public UnitOfMeasurementRepository(AppDbContext context) : base(context)
		{
		}
	}
}
