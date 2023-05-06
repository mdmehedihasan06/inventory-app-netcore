using INVENTORY.Application.ServiceInterfaces.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY.Application.Service.Authentication
{
	public class DataSecurity : IDataSecurity
	{
		private static readonly byte[] Key = Encoding.ASCII.GetBytes("MEHEDI20@23AOWAL"); //MySuperSecretKey12345 MEHEDI20@23AOWAL
		private static readonly byte[] Iv = Encoding.ASCII.GetBytes("2846824876528761"); //1234567890123456

		public string EncryptData(string data)
		{
			try
			{
				using Aes aes = Aes.Create();
				aes.Key = Key;
				aes.IV = Iv;
				byte[] encrypted;
				ICryptoTransform encryptor = aes.CreateEncryptor();
				using MemoryStream msEncrypt = new MemoryStream();
				using CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
				using StreamWriter swEncrypt = new StreamWriter(csEncrypt);
                swEncrypt.Write(data);
                swEncrypt.Flush();
                csEncrypt.FlushFinalBlock();
                encrypted = msEncrypt.ToArray();
                return Convert.ToBase64String(encrypted);
            }
			catch (Exception ex)
			{
				throw;
			}
		}

		public string DecryptData(string encryptedData)
		{
			byte[] cipherText = Convert.FromBase64String(encryptedData);
			using Aes aes = Aes.Create();
			aes.Key = Key;
			aes.IV = Iv;
			string plaintext;
			ICryptoTransform decryptor = aes.CreateDecryptor();
			using MemoryStream msDecrypt = new MemoryStream(cipherText);
			using CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
			using StreamReader srDecrypt = new StreamReader(csDecrypt);
			plaintext = srDecrypt.ReadToEnd();
			return plaintext;
		}

	}
}
