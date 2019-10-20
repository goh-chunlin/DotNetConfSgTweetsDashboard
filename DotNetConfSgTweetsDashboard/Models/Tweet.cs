using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace DotNetConfSgTweetsDashboard.Models
{
    public class Tweet
    {
        public string Author { get; set; }

        public string ProfileImageUrl { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public string TweetContent { get; set; }

        public bool IsContentHavingPhoto { get; set; }

        public string ContentPhotoUrl { get; set; }
    }

    public class Tweets : ObservableCollection<Tweet>
    {
        public Tweets(TweetFeed feed) : base()
        {
            foreach (var tweet in feed.Statuses)
            {
                Add(new Tweet
                {
                    Author = $"@{ tweet.User.ScreenName }",
                    ProfileImageUrl = tweet.User.ProfileImageUrl,
                    CreatedAt = DateTimeOffset.ParseExact(tweet.CreatedAt, "ddd MMM dd HH:mm:ss +ffff yyyy", new System.Globalization.CultureInfo("en-US")),
                    TweetContent = tweet.Content,
                    IsContentHavingPhoto = tweet.ExtendedEntities != null && tweet.ExtendedEntities.Media != null && tweet.ExtendedEntities.Media.Any(m => m.Type == "photo" && !string.IsNullOrEmpty(m.MediaUrl)),
                    ContentPhotoUrl = tweet.ExtendedEntities?.Media?.FirstOrDefault(m => m.Type == "photo" && !string.IsNullOrEmpty(m.MediaUrl))?.MediaUrl
                });
            }

        }
    }
}
