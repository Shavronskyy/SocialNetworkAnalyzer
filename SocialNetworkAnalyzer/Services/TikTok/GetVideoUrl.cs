using HtmlAgilityPack;
using SocialAnalyzer.models;
using System.Xml.Linq;

namespace SocialNetworkAnalyzer.Services.TikTok
{
    public class GetVideoUrl
    {
        public static List<string> GetLink(string url)
        {
            List<string> links = new List<string>();
            try
            {
                HtmlWeb web = new HtmlWeb();
                HtmlDocument doc = web.Load(url);
                var Videos = doc.DocumentNode.SelectNodes(".//div[@class='tiktok-1qb12g8-DivThreeColumnContainer eegew6e2']//div[@data-e2e='user-post-item-list']//div[@class='tiktok-x6y88p-DivItemContainerV2 e19c29qe8']");
                foreach(var video in Videos)
                {
                    var VideoUrl = video.SelectNodes(".//div[@data-e2e='user-post-item']//div[@class='tiktok-1s72ajp-DivWrapper e1cg0wnj1']//a")
                    .First()
                    .Attributes["href"].Value;
                    links.Add(VideoUrl);
                }
                return links;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return links;
        }
    }
}
