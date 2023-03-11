using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAT.Domain.Dtos;
using VAT.Infrastructure.RepositoryInterfaces;

namespace VAT.Infrastructure.Repositories
{
	public class AccountRepository : IAccountRepository
	{
		public Task<string> LogIn(UserDto model)
		{
			throw new NotImplementedException();
		}
	}
}
