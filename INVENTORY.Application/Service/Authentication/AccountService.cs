using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using INVENTORY.Application.ServiceInterfaces.Authentication;
using INVENTORY.Application.ServiceInterfaces.Common;
using INVENTORY.Contracts.Authentication;
using INVENTORY.Contracts.CustomException;
using INVENTORY.Contracts.Response;
using INVENTORY.Domain.Dtos;
using INVENTORY.Domain.Entities.Account;
using INVENTORY.Domain.Entities.Settings;
using INVENTORY.Infrastructure.Constant;
using INVENTORY.Infrastructure.RepositoryInterfaces;
using INVENTORY.Infrastructure.RepositoryInterfaces.Authentication;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Serilog;

namespace INVENTORY.Application.Service.Authentication
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _iAccountRepository;
        private readonly IJwtTokenGenerator _iJwtTokenGenerator;
        private readonly StaticMessages _staticMessages;
        private readonly IDataSecurity _dataSecurity;
		private readonly ILogger<AccountService> _logger;
        private readonly IDateTimeProvider _dateTimeProvider;
		public AccountService(
            IAccountRepository iAccountRepository
			, IJwtTokenGenerator jwtTokenGenerator
            , IOptions<StaticMessages> staticMessages
            , IDataSecurity dataSecurity
			, ILogger<AccountService> logger
            , IDateTimeProvider dateTimeProvider)
        {
			_iAccountRepository = iAccountRepository;
            _iJwtTokenGenerator= jwtTokenGenerator;
            _staticMessages = staticMessages.Value;
            _dataSecurity = dataSecurity;
            _logger = logger;
            _dateTimeProvider = dateTimeProvider;
        }
        public async Task<ApiResponse> Register(UserDto userDto)
        {
			var isNotExist = await _iAccountRepository.IsExistsAsync(u=>u.UserId == userDto.UserId);
            if (!isNotExist) throw new CustomException(_staticMessages.NotAcceptable, HttpStatusCode.NotAcceptable);
			_logger.LogInformation("[App Log] Login registration try for userid: " + userDto.UserId);
			var user = userDto.Adapt<User>();
            user.Password = _dataSecurity.EncryptData(userDto.UserPassword);
            user.CreatedBy = 0;
            user.CreatedDate = _dateTimeProvider.UtcNow;
            user.TenantId = "admin";
            user.Roll = userDto.UserRoll;
            var userObj = await _iAccountRepository.AddAsync(user);
			var userDtoObj = userObj.Adapt<UserDto>();
			return new ApiResponse { StatusCode = StatusCodes.Status200OK, Message = _staticMessages.SuccessfullyRegistered, Data = userDtoObj };
        }

        public async Task<AuthenticationResponse> LogIn(UserDto userDto)
        {
			IReadOnlyList<User>? userObj = await _iAccountRepository.GetAsync(x => x.UserId == userDto.UserId);
			var user = userObj.FirstOrDefault();
            if (user is not null && user.Password is not null)
            {
                if (_dataSecurity.DecryptData(user.Password) == userDto.UserPassword)
                {
                    var token = _iJwtTokenGenerator.GenerateToken(user.Id,user.UserId, user.FirstName, user.Roll);
                    return new AuthenticationResponse
					{
                        Message= _staticMessages.SuccessfullyLogin,
                        Status = (int)HttpStatusCode.OK,
                        user = user,
                        Token = token
                    };
                }
                throw new CustomException(_staticMessages.IncorrectCredentials,HttpStatusCode.BadRequest);
            }
            throw new CustomException(_staticMessages.UserNotFound, HttpStatusCode.NotFound);
		}
    }
}
