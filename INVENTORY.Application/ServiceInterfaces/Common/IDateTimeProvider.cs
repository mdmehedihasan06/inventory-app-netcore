using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY.Application.ServiceInterfaces.Common
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }
}
