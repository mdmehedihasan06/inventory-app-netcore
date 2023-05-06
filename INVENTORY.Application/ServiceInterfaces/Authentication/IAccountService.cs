using INVENTORY.Application.Service.Authentication;
using INVENTORY.Contracts.Authentication;
using INVENTORY.Contracts.Response;
using INVENTORY.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace INVENTORY.Application.ServiceInterfaces.Authentication
{
    public interface IAccountService
    {
        Task<AuthenticationResponse> LogIn(UserDto userDto);
        Task<ApiResponse> Register(UserDto userDto);
    }
}
