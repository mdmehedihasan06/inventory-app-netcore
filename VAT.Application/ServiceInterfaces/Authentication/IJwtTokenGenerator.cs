using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAT.Application.ServiceInterfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(string UserId,string UserName, string Email);
    }
}
