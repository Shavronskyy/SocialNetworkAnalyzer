using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;

namespace SocialNetworkAnalyzer.Controllers
{
    public class GPTController : Controller
    {
        [HttpGet]
        [Route("UseChatGPT")]
        public async Task<IActionResult> UseChatGPT(string query)
        {
            string OutPutResult = "";
            var openai = new OpenAIAPI("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");
            CompletionRequest completionRequest = new CompletionRequest();
            completionRequest.Prompt = query;
            completionRequest.Model = OpenAI_API.Models.Model.DavinciText;

            var completions = openai.Completions.CreateCompletionAsync(completionRequest);
            foreach(var completion in completions.Result.Completions)
            {
                OutPutResult += completion.Text;
            }
            return Ok(OutPutResult);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
