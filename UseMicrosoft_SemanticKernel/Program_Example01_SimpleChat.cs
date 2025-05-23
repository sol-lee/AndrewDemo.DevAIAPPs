﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using System.ComponentModel;


namespace UseMicrosoft_SemanticKernel
{
    internal partial class Program
    {
        static async Task Example01_SimpleChatAsync()
        {
            // https://learn.microsoft.com/en-us/semantic-kernel/get-started/quick-start-guide?pivots=programming-language-csharp

            // Create a new kernel builder, and add AI services to it.
            // Add: OpenAI Chat Completion service.
            var builder = Kernel.CreateBuilder()
                .AddOpenAIChatCompletion(
                    modelId: "gpt-4o-mini",
                    apiKey: OPENAI_APIKEY,
                    httpClient: HttpLogger.GetHttpClient(true));

            var kernel = builder.Build();

            // 正規的程式化作法, 透過 ChatCompletionService / ChatHistory 的操作，來取得對話內容
            var chat = kernel.GetRequiredService<IChatCompletionService>();
            var history = new ChatHistory();
            history.AddSystemMessage("you are a tester, answer me what I ask you.");
            history.AddUserMessage("Say: 'this is a test'.");
            Console.WriteLine(await chat.GetChatMessageContentAsync(history));

            // 對等效果的簡化版本, Prompt Template 可以接受 <xml> format 呈現對話歷程 history
            Console.WriteLine(await kernel.InvokePromptAsync(
                """
                <message role="system">you are a tester, answer me what I ask you.</message>
                <message role="user">Say: 'this is a test'.</message>
                """));

            // 可使用 KernalArguments 傳遞參數
            Console.WriteLine(await kernel.InvokePromptAsync(
                """
                <message role="system">you are a tester, answer me what I ask you.</message>
                <message role="user">Say: '{{$input}}'.</message>
                """,
                new()
                {
                    ["input"] = "this is a test"
                }));

        }
    }

}
