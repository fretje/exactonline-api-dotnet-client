using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ExactOnline.Client.OAuth.Models
{
	public class OAuthTokenResult
	{
		[JsonProperty("access_token", Required = Required.Always)]
		public string AccessToken { get; set; }

		[JsonProperty("token_type", Required = Required.Always)]
		public string TokenType { get; set; }

		[JsonProperty("expires_in", Required = Required.Always)]
		public int ExpiresIn { get; set; }

		[JsonProperty("refresh_token", Required = Required.Always)]
		public string RefreshToken { get; set; }
	}
}
