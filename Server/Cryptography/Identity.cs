using System;

namespace Core.Cryptography
{
	public static class Identity
	{
		public static string NewGUID()
		{
			return Guid.NewGuid().ToString("N");
		}

		public static string NewDateTime()
		{
			return DateTime.UtcNow.Ticks.ToString();
		}

		public static string NewSalt()
		{
			return Encryption.Encrypt(NewGUID());
		}

		public static string TimeStamps(){
			var now = ((long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds).ToString();
			return now;
		}
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

	}
}

