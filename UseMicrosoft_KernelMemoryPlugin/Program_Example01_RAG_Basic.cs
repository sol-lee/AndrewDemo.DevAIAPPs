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
        static async Task Example01_RAG_Basic_Async()
        {
            var builder = Kernel.CreateBuilder();
            builder
                .AddOpenAIChatCompletion(
                    modelId: "gpt-4o",
                    apiKey: OPENAI_APIKEY,
                    httpClient: HttpLogger.GetHttpClient(true));

            var kernel = builder.Build();

            var settings = new OpenAIPromptExecutionSettings
            {
                Temperature = 0,
                //FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
            };


            string question =
                "摘要安德魯寫過的 RAG 主題，它的核心概念是甚麼?";
            // "我想問 Andrew 的 Blog, 開發 microservice 的 SDK 有什麼注意事項嗎?";

            string facts =
                """
                我寫文章時，我會圍繞在特定領域 ( microservices, parallel process, OOP 等) ，挑特定主題 (例如: 架構面試題) 分享我解題的過程，從定義問題，構思解法，設計 POC，開發，模擬驗證的過程交代一次。對我而言，是個很實用的顧問資料庫。不過，有很多人都嫌過我寫太長，消化吸收不容易 (沒辦法，這些題目真的很硬)，不過我還是堅持這樣做，因為這是我個人特色，我寫短篇應該就沒人要看了吧…。事實證明，我這做法，就算是老文章，過了好幾年仍然有參考價值，不會因為技術的替代就被遺忘 (我十年前的文章都還有一定的流量)。而這座法的缺點: 不容易閱讀消化，藉著 GPTs 的發展，正好能替我補足這環節。

                快速回顧一下我的部落格:

                時間: 2004/12/14 寫了第一篇文章至今
                數量: 這期間總共發表了 327 篇文章
                字數: 文字內容部分 (包含程式碼，排除 HTML 等處理格式的部分) 共計 400 萬字
                主題: 軟體開發，架構設計的領域為主。架構師觀點、架構面試題 (解題)、微服務架構、平行處理技巧、物件導向設計等
                這次的 PoC, 我想拿 Chat GPT 當作介面，背後靠 Azure OpenAI 的力量，自己實做 RAG (Retrieval-Augmented Generation, 檢索增強生成) 的機制，結合 GPTs，我想體驗看看這件事能多容易解決。花了不少研就的時間，但是真正花在開發的時間其實很少，如果重做一次，大概不用一天就全部搞定了吧。這次成果，我設計的 “安德魯的部落格 GPTs“，一個擁有我所有文章當作知識庫的對談 AI 機器人。你可以找他詢問、查詢、解題，甚至用不同語言來導讀，GPTs 都能輕鬆應付。突然之間，我覺得過去花心思累積下來的文章是有價值的，AI 的進步非但沒有讓我被淘汰，反而讓我的部落格更有運用的價值了。
                """;

            Console.WriteLine(await kernel.InvokePromptAsync<string>(
                """
                <message role="system">請依據提供的 Facts 為基礎，回覆使用者提出的 Question。若你無法回答請直接回答 "我不知道!"。</message>
                <message role="user">   
                
                # Question
                {{$question}}

                # Facts
                {{$facts}}

                # Answer
                
                </message>
                """,
                new(settings)
                {
                    ["question"] = question,
                    ["facts"] = facts
                }));
        }

    }
}
