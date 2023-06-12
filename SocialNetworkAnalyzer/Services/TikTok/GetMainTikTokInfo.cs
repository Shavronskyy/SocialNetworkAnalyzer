using SocialAnalyzer.models;
using HtmlAgilityPack;
using SocialNetworkAnalyzer.Services.TikTok;

namespace SocialAnalyzer.services.TikTok
{
    public class GetMainTikTokInfo
    {
        public static TikTokUser GetName(string name)
        {
            string url = ("https://www.tiktok.com/@" + name);
            TikTokUser user = new TikTokUser();
            TikTokVideo video = GetVideoInfo.GetVideoStats(GetVideoUrl.GetLink(url));
            try
            {
                HtmlWeb web = new HtmlWeb();
                HtmlDocument doc = web.Load(url);
                user.userTitle = doc.DocumentNode.SelectSingleNode(".//h2[@data-e2e='user-title']").InnerText;
                user.userSubtitle = doc.DocumentNode.SelectSingleNode(".//h1[@data-e2e='user-subtitle']").InnerText;
                user.userSumFollowers = doc.DocumentNode.SelectSingleNode(".//strong[@data-e2e='followers-count']").InnerText;
                user.userFollowing = doc.DocumentNode.SelectSingleNode("//*[@id=\"main-content-others_homepage\"]/div/div[1]/h3/div[1]/strong").InnerText;
                user.userDescription = doc.DocumentNode.SelectSingleNode(".//h2[@data-e2e='user-bio']").InnerText;
                user.userSumLikes = doc.DocumentNode.SelectSingleNode(".//strong[@data-e2e='likes-count']").InnerText;
                user.userImg = doc.DocumentNode.SelectNodes(".//img[@class='tiktok-1zpj2q-ImgAvatar e1e9er4e1']")
                    .First()
                    .Attributes["src"].Value;
                user.userAvgViews = AvgViews.GetAvgViews(url);
                user.userAvgComments = video.CommentsCount;
                user.userAvgViewsToLikes = AvgLikesToViews.LikesToViews(video, user.userAvgViews);
                user.userAvgEngagement = UserEngagement.GetUserEngagement(video, user.userAvgViews);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return user;
        }
    }
}
