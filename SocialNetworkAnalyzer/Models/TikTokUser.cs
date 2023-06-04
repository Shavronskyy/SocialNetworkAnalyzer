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
        public int userAwgViews { get; set; }
        public int userAwgLikes { get; set; }
        public int userAwgComments { get; set; }
        public int userAwgViewsToLikes { get; set; }
        public string userLastMonthFollowers { get; set; }
        public List<TikTokVideo> videos { get; set; }
    }
}
