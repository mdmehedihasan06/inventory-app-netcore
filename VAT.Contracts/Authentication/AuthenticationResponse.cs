using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAT.Contracts.Authentication
{
    public record AuthenticationResponse(
        Guid userId,
        string firstName,
        string lastName,
        string email,
        string token
        );
}
