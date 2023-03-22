using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAT.Infrastructure.RepositoryInterfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(string userId, string firstName, string email);
    }
}
