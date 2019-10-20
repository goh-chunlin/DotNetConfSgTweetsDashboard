using Newtonsoft.Json;
using System.Collections.Generic;

namespace DotNetConfSgTweetsDashboard.Models
{
    public class TweetFeed
    {
        [JsonProperty(PropertyName = "statuses")]
        public IEnumerable<TweetFeedStatus> Statuses { get; set; }
    }
}
