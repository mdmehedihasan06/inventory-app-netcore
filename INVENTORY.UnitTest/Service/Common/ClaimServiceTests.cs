using FluentAssertions;
using INVENTORY.Application.Service.Common;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY.UnitTests.Service.Common
{
	public class ClaimServiceTests
	{
		[Test]
		public void GetClaimValue_ReturnsCorrectValue()
		{
			// Arrange
			var claimType = "test_claim";
			var claimValue = "test_value";
			var claims = new List<Claim> { new Claim(claimType, claimValue) };
			var identity = new ClaimsIdentity(claims, "TestAuthType");
			var principal = new ClaimsPrincipal(identity);
			var httpContext = new DefaultHttpContext { User = principal };
			var httpContextAccessor = new HttpContextAccessor { HttpContext = httpContext };
			var claimService = new ClaimService(httpContextAccessor);

			// Act
			var result = claimService.GetClaimValue(claimType);

			// Assert
			result.Should().Be(claimValue);
		}

		[Test]
		public void GetClaimValue_ReturnsNullWhenClaimNotFound()
		{
			// Arrange
			var claimType = "test_claim";
			var httpContextAccessor = new HttpContextAccessor();
			var claimService = new ClaimService(httpContextAccessor);

			// Act
			var result = claimService.GetClaimValue(claimType);

			// Assert
			result.Should().BeNull();
		}
	}

}
