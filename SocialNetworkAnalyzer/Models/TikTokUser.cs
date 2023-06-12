namespace SocialAnalyzer.models
{
    public class TikTokUser
    {
        public string userTitle { get; set; }
        public string userFollowing { get; set; }
        public string userSubtitle { get; set; }
        public string userSumFollowers { get; set; }
        public string userSumLikes { get; set; }
        public string userDescription { get; set; }
        public string userImg { get; set; }
        public int userAvgViews { get; set; }
        public int userAvgLikes { get; set; }
        public int userAvgComments { get; set; }
        public int userAvgShares { get; set; }
        public int userAvgViewsToLikes { get; set; }
        public double userAvgEngagement { get; set; }
        public string userLastMonthFollowers { get; set; }
        public List<TikTokVideo> videos { get; set; }
    }
}
