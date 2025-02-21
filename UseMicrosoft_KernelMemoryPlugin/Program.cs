// Copyright (c) Microsoft. All rights reserved.

// source: https://github.com/microsoft/kernel-memory/tree/main/examples/003-dotnet-SemanticKernel-plugin

using Microsoft.Extensions.Configuration;
using Microsoft.KernelMemory;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;



namespace UseMicrosoft_KernelMemoryPlugin
{
    public class Program
    {
        private static string OPENAI_APIKEY;
        private static string KERNEL_MEMORY_APIKEY;

        public static async Task Main()
        {
            const string DocFilename = "mydocs-NASA-news.pdf";
            const string Question1 = "any news about Orion?";
            const string Question2 = "any news about Hubble telescope?";
            const string Question3 = "what is a solar eclipse?";
            const string Question4 = "what is my location?";

            IConfigurationRoot config = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();

            OPENAI_APIKEY = config["OpenAI:ApiKey"];
            KERNEL_MEMORY_APIKEY = config["KernelMemory:ApiKey"];


            var builder = Kernel.CreateBuilder();
            builder
                .AddOpenAIChatCompletion(
                    modelId: "gpt-4o",
                    apiKey: OPENAI_APIKEY,
                    httpClient: HttpLogger.GetHttpClient(true));

            //builder.Plugins.AddFromObject(
            //    new MemoryPlugin(
            //         new MemoryWebClient("http://127.0.0.1:9001/", KERNEL_MEMORY_APIKEY),
            //         defaultIndex: "columns.chicken-house.net"),
            //    "memory");

            var kernel = builder.Build();

            kernel.ImportPluginFromObject(
                new MemoryPlugin(
                    new MemoryWebClient("http://127.0.0.1:9001/", KERNEL_MEMORY_APIKEY),
                    defaultIndex: "columns.chicken-house.net"),
                "memory");



            var chat = kernel.GetRequiredService<IChatCompletionService>();
            var settings = new OpenAIPromptExecutionSettings
            {
                Temperature = 0,
                FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
            };


            string question =
                //"安德魯寫過 RAG 的觀念介紹文章嗎? 我想知道 RAG 的運作原理。請給我 RAG 的主要流程與說明";
                "開發 microservice 的 SDK 有什麼注意事項嗎?";

            // 無腦呼叫, 一切都交給 AI 安排
            //Console.WriteLine(await chat.GetChatMessageContentAsync("Q1, 安德魯寫過 RAG 的觀念介紹文章嗎?", settings, kernel));

            // 用 prompt template, 自己規劃如何使用 plugin
            var query = await kernel.InvokePromptAsync<string>("""
                Convert the following question into query, just contain key information for search engine use.
                Give me the query in English, can be a short sentence, or a list of keywords.

                Question: {{$question}}
                Query:
                """,
                new KernelArguments
                {
                    ["question"] = question
                });

            Console.WriteLine(await kernel.InvokePromptAsync(
                //"""
                //Question:   {{$question}}
                //Facts:
                //{{#each memory.Search $query index=$index limit=10 }}
                //    {{ this }}
                //{{/each}}

                //Answer:
                //Include citations to the relevant information where it is referenced in the response.
                //""",
                """
                Include citations to the relevant information where it is referenced in the response.

                Question:   {{$question}}
                Facts:      {{memory.Search $query index=$index limit="5"}}
                
                Answer: (please include facts below)
                """,
                new KernelArguments(settings)
                {
                    ["question"] = question,
                    ["query"] = query,

                    ["index"] = "columns.chicken-house.net",
                    ["limit"] = 1
                }));

            //var search_result = await kernel.Plugins["memory"]["Search"].InvokeAsync(
            //    kernel,
            //    new KernelArguments
            //    {
            //        ["query"] = "RAG 觀念介紹",
            //        ["index"] = "columns.chicken-house.net",
            //        ["limit"] = 10
            //    });
            //Console.WriteLine(search_result);





            if (false)
            {
                //var question = "安德魯寫過 RAG 的觀念介紹文章嗎? 我想知道 RAG 的運作原理。請給我 RAG 的主要流程與說明";
                //var query = await kernel.InvokePromptAsync(
                //    """
                //    將下列問題敘述，轉成英文，並且精簡。我要拿來作內容檢索用。
                //    問題: {{$question}}
                //    查詢: 
                //    """,
                //    new KernelArguments
                //    {
                //        ["question"] = question
                //    });

                var km = new MemoryWebClient("http://127.0.0.1:9001/", KERNEL_MEMORY_APIKEY);
                var search = await km.SearchAsync(
                    query.ToString(), 
                    index: "columns.chicken-house.net", 
                    limit: 10);

                var result = await kernel.InvokePromptAsync(
                    """
                    請依照我給你的事實，回答我的問題。無法回答的就直接回覆 "我不知道"。
                    問題: {{$question}}
                    事實: {{$facts}}
                    答案: 
                    """,
                    new KernelArguments
                    {
                        ["question"] = question,
                        ["facts"] = search
                    });

                Console.WriteLine(result);
            }


            #region removed_code_block
            //// =================================================
            //// === PREPARE SEMANTIC FUNCTION USING DEFAULT INDEX
            //// =================================================

            //var promptOptions = new OpenAIPromptExecutionSettings
            //{
            //    ChatSystemPrompt = """Answer or say "I don't know".""", 
            //    MaxTokens = 100, 
            //    Temperature = 0, 
            //    TopP = 0 
            //};


            //// A simple prompt showing how you can leverage the memory inside prompts and semantic functions.
            //// See how "memory.ask" is used to pass the user question. At runtime the block is replaced with the
            //// answer provided by the memory service.

            //var skPrompt = """
            //           Question: {{$input}}
            //           Tool call result: {{memory.ask $input}}
            //           If the answer is empty say "I don't know", otherwise reply with a preview of the answer, truncated to 15 words.
            //           """;

            //var myFunction = kernel.CreateFunctionFromPrompt(skPrompt, promptOptions);

            //// ==================================================
            //// === PREPARE SEMANTIC FUNCTION USING SPECIFIC INDEX
            //// ==================================================

            //// The same function, reading from a different KM index, called "private"

            //skPrompt = """
            //       Question: {{$input}}
            //       Tool call result: {{memory.ask $input index='private'}}
            //       If the answer is empty say "I don't know", otherwise reply with a preview of the answer, truncated to 15 words.
            //       """;

            //var myFunction2 = kernel.CreateFunctionFromPrompt(skPrompt, promptOptions);

            //// === PREPARE MEMORY PLUGIN ===
            //// Load the Kernel Memory plugin into Semantic Kernel.
            //// We're using a local instance here, so remember to start the service locally first,
            //// otherwise change the URL pointing to your KM endpoint.

            //var memoryConnector = GetMemoryConnector();
            //var memoryPlugin = kernel.ImportPluginFromObject(new MemoryPlugin(memoryConnector, waitForIngestionToComplete: true), "memory");

            //// ==================================
            //// === LOAD DOCUMENTS INTO MEMORY ===
            //// ==================================

            //// Load some data in memory, in this case use a PDF file, though
            //// you can also load web pages, Word docs, raw text, etc.
            //// We load data in the default index (used when an index name is not specified)
            //// and some different data in the "private" index.

            //// You can use either the plugin or the connector, the result is the same
            ////await memoryConnector.ImportDocumentAsync(filePath: DocFilename, documentId: "NASA001");
            //var context = new KernelArguments
            //{
            //    [MemoryPlugin.FilePathParam] = DocFilename,
            //    [MemoryPlugin.DocumentIdParam] = "NASA001"
            //};
            //await memoryPlugin["SaveFile"].InvokeAsync(kernel, context);

            //context = new KernelArguments
            //{
            //    ["index"] = "private",
            //    ["input"] = "I'm located on Earth, Europe, Italy",
            //    [MemoryPlugin.DocumentIdParam] = "PRIVATE01"
            //};
            //await memoryPlugin["Save"].InvokeAsync(kernel, context);
            #endregion

            // ==============================================
            // === RUN SEMANTIC FUNCTION ON DEFAULT INDEX ===
            // ==============================================

            // Run some example questions, showing how the answer is grounded on the document uploaded.
            // Only the first question can be answered, because the document uploaded doesn't contain any
            // information about Question2 and Question3.

            //Console.WriteLine("---------");
            //Console.WriteLine(Question1 + " (expected: some answer using the PDF provided)\n");
            //var answer = await myFunction.InvokeAsync(kernel, Question1);
            //Console.WriteLine("Answer: " + answer);

            //Console.WriteLine("---------");
            //Console.WriteLine(Question2 + " (expected answer: \"I don't know\")\n");
            //answer = await myFunction.InvokeAsync(kernel, Question2);
            //Console.WriteLine("Answer: " + answer);

            //Console.WriteLine("---------");
            //Console.WriteLine(Question3 + " (expected answer: \"I don't know\")\n");
            //answer = await myFunction.InvokeAsync(kernel, Question3);
            //Console.WriteLine("Answer: " + answer);

            //// ================================================
            //// === RUN SEMANTIC FUNCTION ON DIFFERENT INDEX ===
            //// ================================================

            //Console.WriteLine("---------");
            //Console.WriteLine(Question4 + " (expected answer: \"Earth / Europe / Italy\")\n");
            //answer = await myFunction2.InvokeAsync(kernel, Question4);
            //Console.WriteLine("Answer: " + answer);
        }




    }
}