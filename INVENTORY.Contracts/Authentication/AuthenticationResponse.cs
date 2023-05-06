using INVENTORY.Domain.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY.Contracts.Authentication
{
	public class AuthenticationResponse
	{
		public string Message { get; set; }
		public int Status { get; set; }
		public User user { get; set; }
		public string? Token { get; set; }
	}
}
