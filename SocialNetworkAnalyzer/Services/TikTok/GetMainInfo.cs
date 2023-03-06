using SocialAnalyzer.models;
using System;

namespace SocialAnalyzer.services.TikTok
{
    public class GetMainInfo
    {
        public static string GetName(string url)
        {
            string userName = "null";
            //string userSumFollowers;
            //string userSumLikes;
            //string userDescription;
            //string userImg;
            TikTokUser user = new TikTokUser();
            
            try
            {
                using (HttpClientHandler hdl = new HttpClientHandler { AllowAutoRedirect = false, AutomaticDecompression = System.Net.DecompressionMethods.Deflate | System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.None })
                {
                    using (var clnt = new HttpClient(hdl))
                    {
                        using (HttpResponseMessage resp = clnt.GetAsync(url).Result)
                        {
                            if (resp.IsSuccessStatusCode)
                            {
                                var html = resp.Content.ReadAsStringAsync().Result; 
                                if (!string.IsNullOrEmpty(html))
                                {
                                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                                    doc.LoadHtml(html);

                                    userName = doc.DocumentNode.SelectSingleNode(".//h2[@class='tiktok-t89rw6-H2ShareTitle ekmpd5l5']").InnerText;
                                    //user.userSumFollowers = doc.DocumentNode.SelectSingleNode(".//strong[@data-e2e='followers-count']").InnerText;
                                    //user.userDescription = doc.DocumentNode.SelectSingleNode(".//h2[@data-e2e='user-bio']").InnerText;
                                    //user.userSumLikes = doc.DocumentNode.SelectSingleNode(".//strong[@data-e2e='likes-count']").InnerText;
                                    Console.WriteLine(doc.DocumentNode.SelectSingleNode(".//h2[@class='tiktok-t89rw6-H2ShareTitle ekmpd5l5']").InnerText);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message); 
            }
            //return user;
            return userName;
        }
    }
}
