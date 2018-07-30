using System;
using Newtonsoft.Json;

namespace eventizr.Models
{
    public class FbToken
    {
        [JsonProperty("access_token")]
		public string AccessToken { get; set; }

		[JsonProperty("token_type")]
		public string TokenType { get; set;}
    }
}
