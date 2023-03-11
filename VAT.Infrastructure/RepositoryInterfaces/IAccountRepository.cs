using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAT.Domain.Dtos;

namespace VAT.Infrastructure.RepositoryInterfaces
{
	public interface IAccountRepository
	{
		Task<string> LogIn(UserDto model);
	}
}
