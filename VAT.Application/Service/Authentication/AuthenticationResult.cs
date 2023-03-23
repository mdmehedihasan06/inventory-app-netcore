using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAT.Domain.Entities.Account;

namespace VAT.Application.Service.Authentication
{
    public class AuthenticationResult
    {
        public User user { get; set; }
        public string Token { get; set; }
    }
}
