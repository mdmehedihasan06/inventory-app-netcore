using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAT.Application.ServiceInterfaces.Authentication;
using VAT.Domain.Entities.Account;
using VAT.Infrastructure.RepositoryInterfaces;
using VAT.Infrastructure.RepositoryInterfaces.Authentication;

namespace VAT.Application.Service.Authentication
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _iAccountService;
        private readonly IJwtTokenGenerator _iJwtTokenGenerator;
        public AccountService(IAccountRepository iAccountService,IJwtTokenGenerator jwtTokenGenerator)
        {
            _iAccountService = iAccountService;
            _iJwtTokenGenerator= jwtTokenGenerator;
        }
        //check if user Alredy exist
        public async Task<AuthenticationResult> Register(string firstName, string lastName, string email, string password, string confirmPassword)
        {
            // chek confirm pass matching
            // check user Alredy exist
            //create user (generat Guid)
            string userId = Guid.NewGuid().ToString();
            var user = new User();
            var token = string.Empty;

            return new AuthenticationResult
            {
                user = user,
                Token = token
			};
        }

        public async Task<AuthenticationResult> LogIn(string email, string password)
        {

            //get user (generat Guid)
            var userInfo = await _iAccountService.LogIn(email, password);
            var token = _iJwtTokenGenerator.GenerateToken(userInfo.UserId, userInfo.FirstName,userInfo.LastName);

			return new AuthenticationResult
			{
				user = userInfo,
				Token = token
			};
		}
    }
}
