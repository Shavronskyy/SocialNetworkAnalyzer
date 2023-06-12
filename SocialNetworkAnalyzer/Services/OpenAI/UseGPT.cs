using Microsoft.AspNetCore.Mvc;
using OpenAI_API.Completions;
using OpenAI_API;
using System.Security.Cryptography;

namespace SocialNetworkAnalyzer.Services.OpenAI
{
    public class UseGPT
    {
        public static async Task<string> UseChatGPT(string query)
        {
            string OutPutResult = "";
            var openai = new OpenAIAPI("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");
            CompletionRequest completionRequest = new CompletionRequest();
            completionRequest.Prompt = query;
            completionRequest.Model = OpenAI_API.Models.Model.DavinciText;

            var completions = openai.Completions.CreateCompletionAsync(completionRequest);
            foreach (var completion in completions.Result.Completions)
            {
                OutPutResult += completion.Text;
            }
            return OutPutResult;
        }
    }
}
