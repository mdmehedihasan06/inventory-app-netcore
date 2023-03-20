using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAT.Infrastructure.RepositoryInterfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(string userId, string firstName, string email);
    }
}
