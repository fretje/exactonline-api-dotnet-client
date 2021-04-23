using System;

namespace ExactOnline.Client.OAuth
{
	public class UserAuthorization
	{
		public string AccessToken { get; set; }
		public DateTimeOffset? AccessTokenExpiration { get; set; }
		public string RefreshToken { get; set; }
	}
}
