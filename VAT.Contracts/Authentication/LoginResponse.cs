using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAT.Domain.Entities.Account;

namespace VAT.Contracts.Authentication
{
	public class LoginResponse
	{
		public User User { get; set; }
		public string Token { get; set; }
	}
}
