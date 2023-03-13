using SocialAnalyzer.models;
using HtmlAgilityPack;

namespace SocialAnalyzer.services.TikTok
{
    public class GetMainTelegramInfo
    {
        public static async Task<TelegramUser> GetName(string url)
        {
            TelegramUser user = new TelegramUser();
            try
            {
                HtmlWeb web = new HtmlWeb();
                HtmlDocument doc = web.Load(url);
                user.userImg = doc.DocumentNode.SelectNodes(".//img[@class='img-thumbnail box-160-280 rounded-circle']")
                    .First()
                    .Attributes["src"].Value;
                user.userName = doc.DocumentNode.SelectSingleNode(".//div[@class='col-12 col-sm-7 col-md-8 col-lg-6']//h1[@class='text-dark text-center text-sm-left']").InnerText;
                user.userSumFollowers = doc.DocumentNode.SelectSingleNode(".//div[@class='card card-body pt-1 pb-2 position-relative border min-height-155px']//h2[@class='text-dark']").InnerText;
                user.userFollowersToday = doc.DocumentNode.SelectSingleNode(".//div[@class='col col-7 col-sm-5 col-md-6 col-lg-7']//table[@class='mt-1']//tr[1]//b[@class='mr-2 text-danger']").InnerText;
                user.userFollowersWeek = doc.DocumentNode.SelectSingleNode(".//div[@class='col col-7 col-sm-5 col-md-6 col-lg-7']//table[@class='mt-1']//tr[2]//b[@class='mr-2 text-danger']").InnerText;
                user.userFollowersMonth = doc.DocumentNode.SelectSingleNode(".//div[@class='col col-7 col-sm-5 col-md-6 col-lg-7']//table[@class='mt-1']//tr[3]//b[@class='mr-2 text-danger']").InnerText;
                user.userDescription = doc.DocumentNode.SelectSingleNode(".//div[@class='col-12 col-sm-7 col-md-8 col-lg-6']//p[@class='card-text mt-3']").InnerText;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return user;
        }
    }
}
