using VAT.Application.Service.Authentication;
using VAT.Domain.Dtos;

namespace VAT.API.ServiceInterfaces
{
	public interface IAccountService
	{
		Task<AuthenticationResult> LogIn(string email, string password);
	}
}
