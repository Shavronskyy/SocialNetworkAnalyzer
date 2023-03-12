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

namespace SocialAnalyzer.services.TikTok
{
    public class GetMainInfo
    {
        public static async Task<string> GetName(string url)
        {
            TikTokUser user = new TikTokUser();
            string username = "null";
            try
            {
                HtmlWeb web = new HtmlWeb();
                HtmlDocument doc = web.Load(url);
                username = doc.DocumentNode.SelectSingleNode(".//h2[@data-e2e='user-title']").InnerText;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return username;
        }
    }
}
