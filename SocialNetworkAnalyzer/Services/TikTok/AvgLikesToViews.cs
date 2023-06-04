using SocialNetworkAnalyzer.Services.TikTok;

namespace SocialNetworkAnalyzer.Services.TikTok
{
    public class AvgLikesToViews
    {
        public static int LikesToViews(string url)
        {
            int likes = AvgLikes.GetAvgLikes(url);
            int views = AvgViews.GetAvgViews(url);
            double average = Convert.ToDouble(likes) / Convert.ToDouble(views);
            return Convert.ToInt32(average * 100);
        }
    }
}
