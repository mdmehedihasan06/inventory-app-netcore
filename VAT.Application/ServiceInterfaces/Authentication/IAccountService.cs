using VAT.Application.Service.Authentication;
using VAT.Domain.Dtos;

namespace VAT.Application.ServiceInterfaces.Authentication
{
    public interface IAccountService
    {
        Task<AuthenticationResult> LogIn(string email, string password);
    }
}
