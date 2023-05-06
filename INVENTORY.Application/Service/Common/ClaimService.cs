using INVENTORY.Application.ServiceInterfaces.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY.Application.Service.Common
{
	public class ClaimService: IClaimService
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public ClaimService(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		public string GetClaimValue(string claimType)
		{
			if (_httpContextAccessor == null || _httpContextAccessor.HttpContext == null)
			{
				return null;
			}

			var claim = _httpContextAccessor.HttpContext.User.FindFirst(c => c.Type == claimType);

			return claim?.Value;
		}
	}
}
