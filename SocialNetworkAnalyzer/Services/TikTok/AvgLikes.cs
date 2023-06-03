using AngleSharp.Dom;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace SocialNetworkAnalyzer.Services.TikTok
{
    public class AvgLikes
    {
        public static int GetAvgLikes(string url)
        {
            List<int> likesList = new List<int>();
            List<string> links = GetVideoUrl.GetLink(url);
            try
            {
                if (links.Count() == 0)
                {
                    return 2;
                }
                foreach (string link in links)
                {
                    HtmlWeb web = new HtmlWeb();
                    HtmlDocument doc = web.Load(link);
                    var likes = doc.DocumentNode.SelectSingleNode(".//button[@class='tiktok-nmbm7z-ButtonActionItem edu4zum0']//strong[@data-e2e='like-count']").InnerText;
                    if (likes.EndsWith('K'))
                    {
                        likesList.Add(LikesHaveKEnding(likes));
                    }
                    else likesList.Add(Convert.ToInt32(likes));
                }
                return Convert.ToInt32(likesList.Average());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Convert.ToInt32(likesList.Average());
        }
        public static int LikesHaveKEnding(string likes)
        {
            int num;
            bool containDot = true;
            if (!likes.Contains('.'))
            {
                containDot = true;
            }
            if (int.TryParse(likes.Replace(".", "").Replace("K", ""), out num))
            {
                num = containDot ? num *= 100 : num *= 1000;
            }
            return num;
        }
    }
}
