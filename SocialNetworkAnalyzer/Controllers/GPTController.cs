﻿using Microsoft.AspNetCore.Mvc;
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
