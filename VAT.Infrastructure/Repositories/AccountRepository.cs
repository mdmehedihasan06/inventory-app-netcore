using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VAT.Contracts.Authentication;
using VAT.Domain.Entities.Account;
using VAT.Infrastructure.RepositoryInterfaces;
using VAT.Infrastructure.RepositoryInterfaces.Authentication;

namespace VAT.Infrastructure.Repositories
{
	public class AccountRepository : IAccountRepository
	{
		public async Task<User> LogIn(string email, string password)
		{
			var user = new User();
			string token = string.Empty;
			if (email == "admin" && password == "admin")
			{
				user.FirstName = "admin";
				user.LastName = "admin";

			}
			return new User
			{
				UserId = Guid.NewGuid().ToString(),
				FirstName= "admin",
				LastName= "admin",
			};
		}
	}
}
