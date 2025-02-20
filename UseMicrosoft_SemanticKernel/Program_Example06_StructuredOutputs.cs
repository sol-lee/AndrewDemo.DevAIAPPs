using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace UseMicrosoft_SemanticKernel
{
    internal partial class Program
    {
        static async Task Example06_StructuredOutputs_JsonObject_Async()
        {
            // Create a new kernel builder, and add AI services to it.
            // Add: OpenAI Chat Completion service.
            var builder = Kernel.CreateBuilder()
                .AddOpenAIChatCompletion("gpt-4o-mini", OPENAI_APIKEY, OPENAI_ORGID);

            // Add DI services to the builder.
            // Add: Logging services.
            //builder.Services
            //    .AddLogging(services => services.AddConsole().SetMinimumLevel(LogLevel.Trace));

            // Add a chat completion plugin to the builder.


            var kernel = builder.Build();
            var settings = new OpenAIPromptExecutionSettings()
            {
                ResponseFormat = OpenAI.Chat.ChatResponseFormat.CreateJsonObjectFormat()
            };

            // 正規的程式化作法, 透過 ChatCompletionService / ChatHistory 的操作，來取得對話內容
            var chat = kernel.GetRequiredService<IChatCompletionService>();
            
            var result = await chat.GetChatMessageContentAsync(
                """
                How can I solve 8x + 7 = -23?
                response me in this json format: { 'steps': [ { 'explanation': 'reason', 'output': 'result' } ], 'final_answer'': 'answer'' }
                """,
                settings);



            using JsonDocument structuredJson = JsonDocument.Parse(result.ToString());

            Console.WriteLine($"Final answer: {structuredJson.RootElement.GetProperty("final_answer")}");
            Console.WriteLine("Reasoning steps:");

            foreach (JsonElement stepElement in structuredJson.RootElement.GetProperty("steps").EnumerateArray())
            {
                Console.WriteLine($"  - Explanation: {stepElement.GetProperty("explanation")}");
                Console.WriteLine($"    Output: {stepElement.GetProperty("output")}");
            }
        }


        static async Task Example06_StructuredOutputs_JsonSchema_Async()
        {
            // Create a new kernel builder, and add AI services to it.
            // Add: OpenAI Chat Completion service.
            var builder = Kernel.CreateBuilder()
                .AddOpenAIChatCompletion("gpt-4o-mini", OPENAI_APIKEY, OPENAI_ORGID);

            // Add DI services to the builder.
            // Add: Logging services.
            //builder.Services
            //    .AddLogging(services => services.AddConsole().SetMinimumLevel(LogLevel.Trace));

            // Add a chat completion plugin to the builder.


            var kernel = builder.Build();
            var settings = new OpenAIPromptExecutionSettings()
            {
                ResponseFormat = typeof(MathReasoning)
            };

            // 正規的程式化作法, 透過 ChatCompletionService / ChatHistory 的操作，來取得對話內容
            var chat = kernel.GetRequiredService<IChatCompletionService>();

            var result = await chat.GetChatMessageContentAsync(
                """
                How can I solve 8x + 7 = -23?
                response me in this json format: { 'steps': [ { 'explanation': 'reason', 'output': 'result' } ], 'final_answer'': 'answer'' }
                """,
                settings);

            //Console.WriteLine(result.ToString());
            //return;

            var answer = JsonSerializer.Deserialize<MathReasoning>(result.ToString());

            Console.WriteLine($"Final answer: {answer.FinalAnswer}");
            Console.WriteLine("Reasoning steps:");

            foreach (var step in answer.Steps)
            {
                Console.WriteLine($"  - Explanation: {step.Explanation}");
                Console.WriteLine($"    Output: {step.Output}");
            }
        }

        
        public class MathReasoning
        {
            [JsonPropertyName("steps")]
            public List<MathReasoningStep> Steps { get; set; }

            [JsonPropertyName("final_answer")]
            public string FinalAnswer { get; set; }
        }

        public class MathReasoningStep
        {
            [JsonPropertyName("explanation")]
            public string Explanation { get; set; }

            [JsonPropertyName("output")]
            public string Output { get; set; }
        }

    }
}
