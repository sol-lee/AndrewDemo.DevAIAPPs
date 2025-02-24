using Microsoft.KernelMemory;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseMicrosoft_KernelMemoryPlugin
{
    public partial class Program
    {
        static async Task Example04_RAG_With_KernelMemory_Custom_Plugins_Async()
        {
            var builder = Kernel.CreateBuilder();
            builder
                .AddOpenAIChatCompletion(
                    modelId: "gpt-4o",
                    apiKey: OPENAI_APIKEY,
                    httpClient: HttpLogger.GetHttpClient(true));

            var kernel = builder.Build();

            kernel.ImportPluginFromType<AndrewBlogSearchPlugin>("andrew_blog_search");


            var settings = new OpenAIPromptExecutionSettings
            {
                Temperature = 0,
                FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
            };


            string question =
                "摘要安德魯寫過的 RAG 主題，它的核心概念是甚麼?";

            Console.WriteLine(await kernel.InvokePromptAsync<string>(
                """
                <message role="system">

                你的任務是協助使用者找尋相關的資訊，並且依據 search result 為基礎，回覆使用者提出的 Question。
                若你無法回答請直接回答 "我不知道!"。

                回覆問題時，請在最後面附上你參考的資料來源，要包含內容與網址。
                附註的格式如下:

                --
                # 參考資料
                - (1), [參考標題](參考網址): 參考內容
                - (2), [參考標題](參考網址): 參考內容
                </message>
                <message role="user">
                
                # Question
                {{$question}}

                # Answer
                
                </message>
                """,
                new(settings)
                {
                    ["question"] = question
                }));
        }








        public class AndrewBlogSearchPlugin
        {
            [KernelFunction("Search")]
            [Description("Search Andrew's blog for the given query. Andrew is Microsoft MVP, good in .NET and AI application development.")]
            static async Task<string> AndrewBlogSearchResultAsync(
                [Description("The query to search for.")] string query,
                [Description("The index to search in.")] int limit)
            {
                var km = new MemoryWebClient("http://127.0.0.1:9001/", KERNEL_MEMORY_APIKEY);
                var result = await km.SearchAsync(query, index: "columns.chicken-house.net", limit: limit);

                StringBuilder sb = new StringBuilder();
                foreach (var item in result.Results)
                {
                    foreach (var p in item.Partitions)
                    {
                        sb.AppendLine("".PadRight(80, '='));
                        sb.AppendLine($"# Fact:");
                        sb.AppendLine();
                        sb.AppendLine($" - Relevance: {p.Relevance}%");
                        sb.AppendLine($" - Title:     {p.Tags["post-title"][0]}");
                        sb.AppendLine($" - URL:       {p.Tags["post-url"][0]}");

                        sb.AppendLine();
                        sb.AppendLine($"```");
                        sb.AppendLine(p.Text);
                        sb.AppendLine($"```");
                        sb.AppendLine();
                    }
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Kernel Memory Search Results:");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(sb.ToString());
                Console.ResetColor();

                return sb.ToString();
            }
        }
    }
}
