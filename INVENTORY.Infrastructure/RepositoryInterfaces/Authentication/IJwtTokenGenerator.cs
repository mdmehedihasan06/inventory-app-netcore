using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY.Infrastructure.RepositoryInterfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(int Id,string? userId, string? firstName, string? email);
    }
}
