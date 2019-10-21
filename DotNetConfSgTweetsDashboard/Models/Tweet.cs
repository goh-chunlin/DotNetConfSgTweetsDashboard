using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

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

        public Visibility ImageVisibility { get; set; }

        public int Score { get; set; }

        public Visibility ScoreVisibility { get; set; } = Visibility.Collapsed;
    }

    public class Tweets : ObservableCollection<Tweet>
    {
        public Tweets(TweetFeed feed, bool isShowingAllTweets) : base()
        {
            if (isShowingAllTweets)
            {
                foreach (var tweet in feed.Statuses)
                {
                    Add(TransformToTweet(tweet));
                }
            }
            else 
            {
                var statistic = new Dictionary<string, int>();

                foreach (var tweet in feed.Statuses)
                {
                    int score = 1 + tweet.RetweetCount * 5 + tweet.FavouriteCount * 5;

                    if (statistic.Keys.Contains(tweet.User.ScreenName))
                    {
                        statistic[tweet.User.ScreenName] += score;
                    }
                    else
                    {
                        statistic.Add(tweet.User.ScreenName, score);
                    }
                }

                var sortedStatistic = from entry in statistic
                                      orderby entry.Value descending
                                      select entry;

                foreach (var entry in sortedStatistic)
                {
                    var selectedUserTweet = feed.Statuses.FirstOrDefault(s => s.User.ScreenName == entry.Key);

                    var tweetRecord = TransformToTweet(selectedUserTweet);
                    tweetRecord.Score = entry.Value;
                    tweetRecord.ScoreVisibility = Visibility.Visible;

                    Add(tweetRecord);
                }
            }
        }

        private Tweet TransformToTweet(TweetFeedStatus tweet) 
        {
            var tweetImageUrl = tweet.ExtendedEntities?.Media?.FirstOrDefault(m => m.Type == "photo" && !string.IsNullOrEmpty(m.MediaUrl))?.MediaUrl;

            return new Tweet
            {
                Author = $"@{ tweet.User.ScreenName }",
                ProfileImageUrl = tweet.User.ProfileImageUrl,
                CreatedAt = DateTimeOffset.ParseExact(tweet.CreatedAt, "ddd MMM dd HH:mm:ss +ffff yyyy", new System.Globalization.CultureInfo("en-US")),
                TweetContent = tweet.Content,
                IsContentHavingPhoto = tweet.ExtendedEntities != null && tweet.ExtendedEntities.Media != null && tweet.ExtendedEntities.Media.Any(m => m.Type == "photo" && !string.IsNullOrEmpty(m.MediaUrl)),
                ContentPhotoUrl = tweetImageUrl,
                ImageVisibility = string.IsNullOrWhiteSpace(tweetImageUrl) ? Visibility.Collapsed : Visibility.Visible
            };
        }
    }
}
