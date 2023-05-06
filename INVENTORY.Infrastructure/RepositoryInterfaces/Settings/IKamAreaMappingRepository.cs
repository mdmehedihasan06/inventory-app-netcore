using INVENTORY.Domain.Entities.Settings;
using INVENTORY.Infrastructure.RepositoryInterfaces.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY.Infrastructure.RepositoryInterfaces.Settings
{
	public interface IKamAreaMappingRepository:IAsyncRepository<KamAreaMapping>
	{
	}
}
