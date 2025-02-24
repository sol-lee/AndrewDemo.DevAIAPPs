using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel.Plugins.Web.Bing;
using Microsoft.SemanticKernel.Plugins.Web;
using Microsoft.SemanticKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseMicrosoft_KernelMemoryPlugin
{
    public partial class Program
    {
        static async Task Example02_RAG_With_Search_Plugins_Async()
        {
            var builder = Kernel.CreateBuilder();
            builder
                .AddOpenAIChatCompletion(
                    modelId: "gpt-4o",
                    apiKey: OPENAI_APIKEY,
                    httpClient: HttpLogger.GetHttpClient(true));

            var kernel = builder.Build();

#pragma warning disable SKEXP0050 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
            var bingConnector = new BingConnector(BING_SEARCH_APIKEY);
            var bing = new WebSearchEnginePlugin(bingConnector);
            kernel.ImportPluginFromObject(bing, "bing");
#pragma warning restore SKEXP0050 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.


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

                你的任務是協助使用者，到 bing search 找尋相關的資訊，並且依據 search result 為基礎，回覆使用者提出的 Question。
                若你無法回答請直接回答 "我不知道!"。

                搜尋的範圍限定於 "安德魯的部落格"，網址是 https://columns.chicken-house.net/  , 並且限制搜尋結果數量為 10。

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

    }
}
