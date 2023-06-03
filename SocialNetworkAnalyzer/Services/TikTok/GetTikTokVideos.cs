using HtmlAgilityPack;
using SocialAnalyzer.models;

namespace SocialNetworkAnalyzer.Services.TikTok
{
    public class GetTikTokVideos
    {
        public static async Task<List<TikTokVideo>> GetListOfVideos(string url)
        {
            List<TikTokVideo> listOfVideos = new List<TikTokVideo>();
            try
            {
                HtmlWeb web = new HtmlWeb();
                HtmlDocument doc = web.Load(url);
                var videos = doc.DocumentNode.SelectNodes(".//div[@data-e2e='user-post-item-list']//div[@class='tiktok-x6y88p-DivItemContainerV2 e19c29qe7']");
                foreach(var item in videos)
                {
                    TikTokVideo video = new TikTokVideo();
                    video.Title = item.SelectNodes(".//div[@data-e2e='user-post-item-desc']//a[@class='tiktok-1wrhn5c-AMetaCaptionLine eih2qak0']")
                    .First()
                    .Attributes["title"].Value;
                    video.Views = doc.DocumentNode.SelectSingleNode(".//strong[@data-e2e='video-views']").InnerText;
                    video.Img = doc.DocumentNode.SelectNodes(".//div[@class='tiktok-1jxhpnd-DivContainer e1yey0rl0']//img[@class='tiktok-1itcwxg-ImgPoster e1yey0rl1']")
                        .First()
                        .Attributes["src"].Value;
                    listOfVideos.Add(video);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return listOfVideos;
        }
    }
}
