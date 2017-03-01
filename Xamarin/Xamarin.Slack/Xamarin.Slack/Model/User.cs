using System;
using Newtonsoft.Json;

namespace Xamarin.Slack.Model
{
	public class User
	{
		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }
		[JsonProperty(PropertyName = "real_name")]
		public string RealName { get; set; }
		[JsonProperty(PropertyName = "id")]
		public string Id { get; set; }
		public Profile Profile { get; set; }
	}

	public class Profile
	{
		[JsonProperty(PropertyName = "image_original")]
		public string Avatar { get; set; }
	}
}
