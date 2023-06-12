using SocialAnalyzer.models;
using SocialNetworkAnalyzer.Services.TikTok;

namespace SocialNetworkAnalyzer.Services.TikTok
{
    public class AvgLikesToViews
    {
        public static int LikesToViews(TikTokVideo video, int averageViews)
        {
            double average = Convert.ToDouble(video.LikesCount) / Convert.ToDouble(averageViews);
            return Convert.ToInt32(average * 100);
        }
    }
}
