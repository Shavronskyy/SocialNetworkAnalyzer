namespace SocialAnalyzer.models
{
    public class TikTokUser
    {
        public string userTitle { get; set; }
        public string userSubtitle { get; set; }
        public string userSumFollowers { get; set; }
        public string userSumLikes { get; set; }
        public string userDescription { get; set; }
        public string userImg { get; set; }
        public double userAwgViews { get; set; }
        public List<TikTokVideo> videos { get; set; }
    }
}
