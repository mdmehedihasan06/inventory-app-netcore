using VAT.Domain.Dtos;

namespace VAT.API.ServiceInterfaces
{
	public interface IAccountService
	{
		Task<string> LogIn(LoginModel model);
	}
}
