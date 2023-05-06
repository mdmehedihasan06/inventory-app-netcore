using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY.Application.ServiceInterfaces.Authentication
{
	public interface IDataSecurity
	{
		public string EncryptData(string data);
		public string DecryptData(string encryptedData);
	}
}
