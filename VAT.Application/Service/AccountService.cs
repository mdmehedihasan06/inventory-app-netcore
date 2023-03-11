using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAT.API.ServiceInterfaces;
using VAT.Domain.Dtos;
using VAT.Infrastructure.RepositoryInterfaces;

namespace VAT.Application.Service
{
	public class AccountService : IAccountService
	{
		private readonly IAccountRepository _iAccountRepository;
		public AccountService(IAccountRepository accountRepository)
		{
			_iAccountRepository= accountRepository;
		}
		public async Task<string> LogIn(LoginModel model)
		{
			return await _iAccountRepository.LogIn(model);
		}
	}
}
