using Newtonsoft.Json;

namespace DotNetConfSgTweetsDashboard.Models
{
    public class TweetFeedStatus
    {
        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty(PropertyName = "full_text")]
        public string Content { get; set; }

        [JsonProperty(PropertyName = "user")]
        public TweetFeedUser User { get; set; }

        [JsonProperty(PropertyName = "extended_entities")]
        public ExtendedEntity ExtendedEntities { get; set; }

        [JsonProperty(PropertyName = "retweet_count")]
        public int RetweetCount { get; set; }

        [JsonProperty(PropertyName = "favorite_count")]
        public int FavouriteCount { get; set; }
    }
}
