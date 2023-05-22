using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;

namespace SocialNetworkAnalyzer.Services.TikTok
{
    public class AvgViews
    {
        public int GetAvgViews(HtmlNodeCollection videoViews)
        {
            List<int> avgViewsCount = new List<int>();
            foreach (var views in videoViews)
            {
                if (views.InnerText.EndsWith('K'))
                {
                    avgViewsCount.Add(ViewsHaveKEnding(views));
                }
                else if (!views.InnerText.EndsWith('K'))
                {
                    avgViewsCount.Add(Convert.ToInt32(views.InnerText));
                } else if (views.InnerText.EndsWith('M'))
                {
                    avgViewsCount.Add(ViewsHaveMEnding(views));
                }
            }  
            return (int)avgViewsCount.Average();
        }
        public int ViewsHaveKEnding(HtmlNode views)
        {
            int num = 0;
            if (int.TryParse(views.InnerText.Replace(".", "").Replace("K", ""), out num))
            {
                num *= 100;
            }
            return num;
        }
        public int ViewsHaveMEnding(HtmlNode views)
        {
            int num = 0;
            if (int.TryParse(views.InnerText.Replace(".", "").Replace("M", ""), out num))
            {
                num *= 100000;
            }
            return num;
        }
    }
}
