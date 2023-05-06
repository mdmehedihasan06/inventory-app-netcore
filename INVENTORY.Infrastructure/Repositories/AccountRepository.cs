using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using INVENTORY.Contracts.Authentication;
using INVENTORY.Domain.Entities.Account;
using INVENTORY.Infrastructure.RepositoryInterfaces;
using INVENTORY.Infrastructure.RepositoryInterfaces.Authentication;
using INVENTORY.Infrastructure.Repositories.Generic;
using INVENTORY.Infrastructure.Context;

namespace INVENTORY.Infrastructure.Repositories
{
	public class AccountRepository : RepositoryBase<User>, IAccountRepository
	{
		public AccountRepository(AppDbContext context) : base(context)
		{

		}
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
