using Newtonsoft.Json;

namespace DotNetConfSgTweetsDashboard.Models
{
    public class TweetFeedUser
    {
        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }

        [JsonProperty(PropertyName = "screen_name")]
        public string ScreenName { get; set; }

        [JsonProperty(PropertyName = "profile_image_url")]
        public string ProfileImageUrl { get; set; }
    }
}
