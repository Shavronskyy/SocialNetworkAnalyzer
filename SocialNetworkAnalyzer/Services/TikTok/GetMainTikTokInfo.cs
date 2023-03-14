using SocialAnalyzer.models;
using System.Net.Http;
using System;
using AngleSharp.Html.Parser;
using AngleSharp;
using System.Net;
using AngleSharp.Dom;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Collections;
using System.Reflection.Metadata;
using System.Xml.Linq;
using HtmlAgilityPack;
using SocialNetworkAnalyzer.Services.TikTok;

namespace SocialAnalyzer.services.TikTok
{
    public class GetMainTikTokInfo
    {
        public static async Task<TikTokUser> GetName(string url)
        {
            TikTokUser user = new TikTokUser();
            string username = "null";
            try
            {
                HtmlWeb web = new HtmlWeb();
                HtmlDocument doc = web.Load(url);
                user.userTitle = doc.DocumentNode.SelectSingleNode(".//h2[@data-e2e='user-title']").InnerText;
                user.userSubtitle = doc.DocumentNode.SelectSingleNode(".//h1[@data-e2e='user-subtitle']").InnerText;
                user.userSumFollowers = doc.DocumentNode.SelectSingleNode(".//strong[@data-e2e='followers-count']").InnerText;
                user.userDescription = doc.DocumentNode.SelectSingleNode(".//h2[@data-e2e='user-bio']").InnerText;
                user.userSumLikes = doc.DocumentNode.SelectSingleNode(".//strong[@data-e2e='likes-count']").InnerText;
                user.userImg = doc.DocumentNode.SelectNodes(".//img[@class='tiktok-1zpj2q-ImgAvatar e1e9er4e1']")
                    .First()
                    .Attributes["src"].Value;
                user.videos = GetTikTokVideos.GetListOfVideos(url).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return user;
        }
    }
}
