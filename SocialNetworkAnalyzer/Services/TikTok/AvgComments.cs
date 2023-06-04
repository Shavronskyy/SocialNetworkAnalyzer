using HtmlAgilityPack;

namespace SocialNetworkAnalyzer.Services.TikTok
{
    public class AvgComments
    {
        public static int GetAvgComments(string url)
        {
            List<int> CommentsList = new List<int>();
            List<string> links = GetVideoUrl.GetLink(url);
            try
            {
                if (links.Count() == 0)
                {
                    return -1;
                }
                foreach (string link in links)
                {
                    HtmlWeb web = new HtmlWeb();
                    HtmlDocument doc = web.Load(link);
                    var comments = doc.DocumentNode.SelectSingleNode(".//button[@class='tiktok-nmbm7z-ButtonActionItem edu4zum0']//strong[@data-e2e='comment-count']").InnerText;
                    if (comments.EndsWith('K'))
                    {
                        CommentsList.Add(CommentsHaveKEnding(comments));
                    }
                    else CommentsList.Add(Convert.ToInt32(comments));
                }
                return Convert.ToInt32(CommentsList.Average());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Convert.ToInt32(CommentsList.Average());
        }
        public static int CommentsHaveKEnding(string comments)
        {
            int num;
            bool containDot = true;
            if (!comments.Contains('.'))
            {
                containDot = true;
            }
            if (int.TryParse(comments.Replace(".", "").Replace("K", ""), out num))
            {
                num = containDot ? num *= 100 : num *= 1000;
            }
            return num;
        }
    }
}
