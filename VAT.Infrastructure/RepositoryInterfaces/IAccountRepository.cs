using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAT.Contracts.Authentication;
using VAT.Domain.Entities.Account;

namespace VAT.Infrastructure.RepositoryInterfaces
{
    public interface IAccountRepository
    {
        Task<User> LogIn(string email, string password);
    }
}
