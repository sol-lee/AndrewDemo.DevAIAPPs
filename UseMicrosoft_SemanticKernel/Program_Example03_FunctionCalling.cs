using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using System.ComponentModel;

namespace UseMicrosoft_SemanticKernel
{
    internal partial class Program
    {
        static async Task Example03_FunctionCalling_PromptTemplate2_Async()
        {
            // Create a new kernel builder, and add AI services to it.
            // Add: OpenAI Chat Completion service.
            var builder = Kernel.CreateBuilder()
                .AddOpenAIChatCompletion(
                    modelId: "gpt-4o-mini",
                    apiKey: OPENAI_APIKEY,
                    httpClient: HttpLogger.GetHttpClient(true));

            // Add DI services to the builder.
            // Add: Logging services.
            //builder.Services
            //    .AddLogging(services => services.AddConsole().SetMinimumLevel(LogLevel.Trace));

            // Add a chat completion plugin to the builder.
            builder.Plugins.AddFromType<WeatherPlugins>();

            var kernel = builder.Build();
            var settings = new PromptExecutionSettings()
            {
                FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
            };

            // 透過 PromptTemplate 的方式，來取得對話內容
            // 你能明確在 template 呼叫 plugin, 這時 semantic kernel 會直接在本地端幫你處理掉 (不用透過 LLM)
            // 但是你仍然保有 function calling 讓 AI 幫你計畫執行方式的彈性
            Console.WriteLine(await kernel.InvokePromptAsync<string>(
                """
                <message role="user">
                My current location is {{WeatherPlugins.GetCurrentLocation}}
                </message>
                <message role="user">
                What is the weather like today?
                </message>
                """,
                new(settings)));
        }



        static async Task Example03_FunctionCalling_PromptTemplate_Async()
        {
            // Create a new kernel builder, and add AI services to it.
            // Add: OpenAI Chat Completion service.
            var builder = Kernel.CreateBuilder()
                .AddOpenAIChatCompletion(
                    modelId: "gpt-4o-mini",
                    apiKey: OPENAI_APIKEY,
                    httpClient: HttpLogger.GetHttpClient(true));

            // Add DI services to the builder.
            // Add: Logging services.
            //builder.Services
            //    .AddLogging(services => services.AddConsole().SetMinimumLevel(LogLevel.Trace));

            // Add a chat completion plugin to the builder.
            builder.Plugins.AddFromType<WeatherPlugins>();

            var kernel = builder.Build();
            var settings = new PromptExecutionSettings()
            {
                FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
            };

            // 透過 PromptTemplate 的方式，來取得對話內容
            // 你能明確在 template 呼叫 plugin, 這時 semantic kernel 會直接在本地端幫你處理掉 (不用透過 LLM)
            // 但是你仍然保有 function calling 讓 AI 幫你計畫執行方式的彈性
            Console.WriteLine(await kernel.InvokePromptAsync<string>(
                """
                What is the weather like today?
                """,
                new(settings)));
        }



        static async Task Example03_FunctionCalling_ChatCompletion_Async()
        {
            // Create a new kernel builder, and add AI services to it.
            // Add: OpenAI Chat Completion service.
            var builder = Kernel.CreateBuilder()
                .AddOpenAIChatCompletion(
                    modelId: "gpt-4o-mini",
                    apiKey: OPENAI_APIKEY,
                    httpClient: HttpLogger.GetHttpClient(true));

            // Add DI services to the builder.
            // Add: Logging services.
            //builder.Services
            //    .AddLogging(services => services.AddConsole().SetMinimumLevel(LogLevel.Trace));

            // Add a chat completion plugin to the builder.
            builder.Plugins.AddFromType<WeatherPlugins>();

            var kernel = builder.Build();
            var settings = new PromptExecutionSettings()
            {
                FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
            };

            // 正規的程式化作法, 透過 ChatCompletionService / ChatHistory 的操作，來取得對話內容
            var chat = kernel.GetRequiredService<IChatCompletionService>();
            var history = new ChatHistory();
            history.AddUserMessage(
                """
                What is the weather like today?
                """);
            Console.WriteLine(await chat.GetChatMessageContentAsync(
                history,
                settings,
                kernel));


            //Console.WriteLine(await kernel.InvokePromptAsync(
            //    """
            //    What is the weather like today?
            //    """,
            //    new(settings)));
        }


        public class WeatherPlugins
        {
            [KernelFunction("GetCurrentLocation")]
            [Description("Get the user's current location")]
            public string GetCurrentLocation()
            {
                Console.WriteLine($"// call: GetCurrentLocation()");
                return "Taipei";
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
