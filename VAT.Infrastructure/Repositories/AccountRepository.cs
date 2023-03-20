using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VAT.Infrastructure.RepositoryInterfaces;

namespace VAT.Infrastructure.Repositories
{
	public class AccountRepository : IAccountRepository
	{
		public Task<string> LogIn(string email, string password)
		{
			if (email == "admin" && password == "admin")
			{
				return Task.FromResult("Login Successful.");
			}
			return Task.FromResult(HttpStatusCode.NotFound.ToString());
		}
	}
}
