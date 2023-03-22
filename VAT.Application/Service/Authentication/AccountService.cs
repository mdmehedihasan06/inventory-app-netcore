using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAT.Application.ServiceInterfaces.Authentication;
using VAT.Infrastructure.RepositoryInterfaces;
using VAT.Infrastructure.RepositoryInterfaces.Authentication;

namespace VAT.Application.Service.Authentication
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _iAccountService;
        public AccountService(IAccountRepository iAccountService)
        {
            _iAccountService = iAccountService;
        }
        //check if user Alredy exist
        public async Task<AuthenticationResult> Register(string firstName, string lastName, string email, string password, string confirmPassword)
        {
            // chek confirm pass matching
            // check user Alredy exist
            //create user (generat Guid)
            string userId = Guid.NewGuid().ToString();
            var token = await _iAccountService.LogIn(email, password);

            return new AuthenticationResult
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Token = token
			};
        }

        public async Task<AuthenticationResult> LogIn(string email, string password)
        {

            //get user (generat Guid)
            var token = await _iAccountService.LogIn(email, password);

			return new AuthenticationResult
			{
				Id = Guid.NewGuid().ToString(),
				Email = email,
				Token = token
			};
		}
    }
}
