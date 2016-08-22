using System;
using System.Configuration;

namespace Core.Cryptography
{
	public class Config
	{
		public static string ClientId
		{
			get
			{
				return Read("core.cryptography.clientid", "635151941061126793");
			}
		}

		public static string ClientPassword
		{
			get
			{
				return Read("core.cryptography.clientpass", "L7IMTpeg6rA1FjDIEh6QH9fUw5t5j4AzQLoaNtK4H");
			}
		}

		public static string Salt
		{
			get
			{
				return Read("core.cryptography.salt", "4d563039b9e440b5a656d915099f3aaf");
			}
		}

		public static string Spice
		{
			get
			{
				return Read("core.cryptography.spice", "E6*-vC/RO");
			}
		}

		public static string Passphrase
		{
			get
			{
				return Read("core.cryptography.passphrase", "99ec6d47462344809d8258218910bd75");
			}
		}

		public static string HashAlgorithm
		{
			get
			{
				return Read("core.cryptography.hashalgorithm", "SHA1");
			}
		}

		public static int PasswordIterations
		{
			get
			{
				return Read("core.cryptography.passworditerations", 91);
			}
		}

		public static string InitVector
		{
			get
			{
				// must be exactly 16 bytes
				return Read("core.cryptography.initvector", "mkPfnNZJja0tB6+c");
			}
		}

		public static int KeySize
		{
			get
			{
				// 128 or 192 or 256
				return Read("core.cryptography.keysize", 256);
			}
		}

		public static int WSCallValidity
		{
			get
			{
				return Read("core.cryptography.wscallvalidity", 6);
			}
		}

		// awesome read
		private static T Read<T>(string key, T @default = default(T))
		{
			var temp = string.Empty;//ConfigurationManager.AppSettings[key];
			return !string.IsNullOrWhiteSpace(temp) ? (T)Convert.ChangeType(temp, typeof(T)) : @default;
		}
	}
}

