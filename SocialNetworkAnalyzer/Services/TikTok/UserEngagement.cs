using AngleSharp.Dom;
using HtmlAgilityPack;
using SocialAnalyzer.models;

namespace SocialNetworkAnalyzer.Services.TikTok
{
    public class UserEngagement
    {
        public static double GetUserEngagement(TikTokVideo video, int averageViews)
        {
            double average = (Convert.ToDouble(video.LikesCount) + Convert.ToDouble(video.CommentsCount) + Convert.ToDouble(video.SharesCount)) / averageViews;
            return  Math.Round(average * 100, 2);
        }
    }
}
