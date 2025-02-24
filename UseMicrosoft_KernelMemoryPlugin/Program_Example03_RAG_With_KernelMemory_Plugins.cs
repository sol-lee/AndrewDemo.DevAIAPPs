using Microsoft.KernelMemory;
using Microsoft.SemanticKernel.Connectors.OpenAI;
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
        static async Task Example03_RAG_With_KernelMemory_Plugins_Async()
        {
            var builder = Kernel.CreateBuilder();
            builder
                .AddOpenAIChatCompletion(
                    modelId: "gpt-4o",
                    apiKey: OPENAI_APIKEY,
                    httpClient: HttpLogger.GetHttpClient(true));

            var kernel = builder.Build();


            kernel.ImportPluginFromObject(
                new MemoryPlugin(
                    new MemoryWebClient("http://127.0.0.1:9001/", KERNEL_MEMORY_APIKEY),
                    defaultIndex: "columns.chicken-house.net"),
                "kernel_memory");

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

                你的任務是協助使用者，到 kernel_memory search 相關的資訊，並且依據 search result 為基礎，回覆使用者提出的 Question。
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

    }
}
