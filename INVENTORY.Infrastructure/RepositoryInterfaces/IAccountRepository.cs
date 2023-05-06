using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INVENTORY.Contracts.Authentication;
using INVENTORY.Domain.Entities.Account;
using INVENTORY.Infrastructure.RepositoryInterfaces.Generic;

namespace INVENTORY.Infrastructure.RepositoryInterfaces
{
    public interface IAccountRepository : IAsyncRepository<User>
	{
        Task<User> LogIn(string email, string password);
    }
}
