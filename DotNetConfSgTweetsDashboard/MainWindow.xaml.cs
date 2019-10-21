using System.Windows;
using Tweetinvi;
using System.Configuration;
using Tweetinvi.Json;
using Newtonsoft.Json;
using DotNetConfSgTweetsDashboard.Models;

namespace DotNetConfSgTweetsDashboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isShowingAllTweets = true;

        public MainWindow()
        {
            InitializeComponent();

            Auth.SetUserCredentials(
                ConfigurationManager.AppSettings["Twitter_ConsumerApiKey"].ToString(),
                ConfigurationManager.AppSettings["Twitter_ConsumerApiSecret"].ToString(),
                ConfigurationManager.AppSettings["Twitter_AccessToken"].ToString(),
                ConfigurationManager.AppSettings["Twitter_AccessTokenSecret"].ToString());

            UpdateTweets();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            UpdateTweets();
        }

        private void btnSwitchMode_Click(object sender, RoutedEventArgs e)
        {
            isShowingAllTweets = !isShowingAllTweets;

            btnSwitchMode.Content = isShowingAllTweets ? "SHOW RANKING" : "SHOW RECENT TWEETS";

            UpdateTweets();
        }

        private void UpdateTweets()
        {
            string tweetFeedInJson = SearchJson.SearchTweets("dotnetconfsg");

            var tweetFeed = JsonConvert.DeserializeObject<TweetFeed>(tweetFeedInJson);

            this.DataContext = new Tweets(tweetFeed, isShowingAllTweets);
        }
    }
}
