using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY.Contracts.Request
{
    public class LoginModel
    {
        public string UserId { get; set; }
        public string UserPassword { get; set; }
    }
}
