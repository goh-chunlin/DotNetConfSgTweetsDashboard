using Newtonsoft.Json;
using System.Collections.Generic;

namespace DotNetConfSgTweetsDashboard.Models
{
    public class ExtendedEntity
    {
        [JsonProperty(PropertyName = "media")]
        public IEnumerable<MediaEntity> Media { get; set; }
    }
}
