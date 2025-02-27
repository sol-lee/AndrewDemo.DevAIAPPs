using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.KernelMemory;
using System.ComponentModel;

namespace UseMicrosoft_KernelMemoryPlugin
{
    public partial class Program
    {
        static async Task Example06_MultiplePluginsDemo_Async()
        {
            //
            var builder = Kernel.CreateBuilder();
            builder
                .AddOpenAIChatCompletion(
                    modelId: "gpt-4o",
                    apiKey: OPENAI_APIKEY,
                    httpClient: HttpLogger.GetHttpClient(true));

            builder.Plugins
                .AddFromType<NewsSearchPlugin>("news")
                .AddFromType<WeatherPlugins>("weather")
                .AddFromType<AndrewBlogSearchPlugin>("andrew_blog_search");

            var kernel = builder.Build();

            var settings = new OpenAIPromptExecutionSettings
            {
                //ChatSystemPrompt = "Answer or say \"I don't know\".",
                Temperature = 0,
                FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
            };



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
                    ["question"] = 
                    """
                    我從西元 2100 穿越過來，請問我現在在哪裡?
                    今天的日期是? 現在的時間是?
                    給我當地相關的新聞，另外我也想知道現在 AI 發展到什麼程度了，找幾篇討論 AI 趨勢發展比較深入的文章，部落格，或是新聞都可以。
                    摘要 100 字大綱給我。
                    """
                }));

            // note, AI 應該要從手上能使用的 tools 清單，以及使用者的要求
            // 規劃出正確的 planning, 並且依序執行 tools
            // 取得必要資訊後，最後再統整回答問題

            // 預期:
            // - 找出現在地點
            // - 搜尋當地新聞
            // - 搜尋當地氣象

        }

        public class NewsSearchPlugin
        {
            [KernelFunction]
            [Description("search for public information, like news, or blog article in my local article base.")]
            static async Task<string> SearchPublicNews(string query)
            {
                return await _SearchKernelMemory(query, "default", 5, 0.2);
            }

            static async Task<string> _SearchKernelMemory(string query, string index, int limit, double minRelevance)
            {
                var km = new MemoryWebClient("http://127.0.0.1:9001/", KERNEL_MEMORY_APIKEY);
                var result = await km.SearchAsync(
                    query, 
                    index: index, 
                    limit: limit,
                    minRelevance: minRelevance);

                StringBuilder sb = new StringBuilder();
                foreach (var item in result.Results)
                {
                    foreach (var p in item.Partitions)
                    {
                        sb.AppendLine("".PadRight(80, '='));
                        sb.AppendLine($"# Fact (Relevance: {p.Relevance}%):");

                        sb.AppendLine();
                        sb.AppendLine(p.Text);
                        sb.AppendLine();
                    }
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Kernel Memory Search Results(query: {query}, index: {index}):");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(sb.ToString());
                Console.ResetColor();

                return sb.ToString();

            }
        }

        public class WeatherPlugins
        {
            [KernelFunction("GetCurrentLocation")]
            [Description("Get the user's current location via GPS")]
            public string GetCurrentLocation()
            {
                Console.WriteLine($"// call: GetCurrentLocation()");
                //return "Taipei";
                //return "關渡";
                //return "Italy";
                return "San Diego";
            }

            [KernelFunction("GetCurrentDateTime")]
            [Description("Get the user's current date time.")]
            public DateTime GetCurrentDateTime()
            {
                Console.WriteLine($"// call: GetCurrentDateTime()");
                return DateTime.UtcNow;
            }

            [KernelFunction("GetCurrentWeather")]
            [Description("Get the current weather in a given location")]
            public string GetCurrentWeather(
                [Description("The city and state, e.g. Boston, MA")]
                string location,

                [Description("The temperature unit to use. Infer this from the specified location.")]
                TemperatureUnit unit)
            {
                Console.WriteLine($"// call: GetCurrentWeather(location: '{location}', unit: '{unit}')");
                return $"16 {unit}";
            }

            public enum TemperatureUnit
            {
                [Description("Celsius")]
                Celsius,
                [Description("Fahrenheit")]
                Fahrenheit
            }
        }
    }
}
