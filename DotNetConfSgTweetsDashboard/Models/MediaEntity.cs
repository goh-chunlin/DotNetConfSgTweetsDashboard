using Newtonsoft.Json;

namespace DotNetConfSgTweetsDashboard.Models
{
    public class MediaEntity
    {
        [JsonProperty(PropertyName = "media_url_https")]
        public string MediaUrl { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    }
}
