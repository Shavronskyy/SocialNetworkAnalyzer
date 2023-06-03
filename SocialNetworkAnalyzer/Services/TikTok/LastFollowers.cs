using AngleSharp.Dom;
using HtmlAgilityPack;
using static System.Net.WebRequestMethods;

namespace SocialNetworkAnalyzer.Services.TikTok
{
    public class LastFollowers
    {
        public static string GetLastMonthFollowersCount(string name)
        {
            string url = "https://socialblade.com/tiktok/user/" + name;
                HtmlWeb web = new HtmlWeb();
                HtmlDocument doc = web.Load(url);
            var userImg = doc.DocumentNode.SelectNodes(".//[@id='socialblade-user-content']//div[12]//div[2]//span");
            return userImg.Count().ToString();
        }
    }
}
