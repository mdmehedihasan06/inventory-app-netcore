using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAT.API.ServiceInterfaces;
using VAT.Infrastructure.RepositoryInterfaces;

namespace VAT.Application.Service.Authentication
{
    public class AccountService : IAccountService
    {
        private readonly IJwtTokenGenerator _iJwtTokenGenerator;
        private readonly IAccountRepository _iAccountService;
        public AccountService(IJwtTokenGenerator jwtTokenGenerator, IAccountRepository iAccountService)
        {
            _iJwtTokenGenerator = jwtTokenGenerator;
            _iAccountService = iAccountService;
        }
        //check if user Alredy exist
        public AuthenticationResult Register(string firstName, string lastName, string email, string Password, string confirmPassword)
        {
            // chek confirm pass matching
            // check user Alredy exist
            //create user (generat Guid)
            string userId = Guid.NewGuid().ToString();
            //crete jwt token
            string token = _iJwtTokenGenerator.GenerateToken(userId, firstName, email);

            return new AuthenticationResult
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Token = "token"
            };
        }

        public async Task<AuthenticationResult> LogIn(string email, string password)
        {

            //get user (generat Guid)
            var user = await _iAccountService.LogIn(email, password);
            //crete jwt token
            string token = _iJwtTokenGenerator.GenerateToken(Guid.NewGuid().ToString(), email, email);

            return new AuthenticationResult
            {
                Id = Guid.NewGuid().ToString(),
                FullName = "Name",
                Email = email,
                Token = token
            };
        }
    }
}
