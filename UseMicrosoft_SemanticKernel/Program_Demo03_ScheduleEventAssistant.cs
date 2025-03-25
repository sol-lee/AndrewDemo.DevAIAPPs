using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using System.ComponentModel;

namespace UseMicrosoft_SemanticKernel
{
    internal partial class Program
    {
        static async Task Demo03_ScheduleEvent_Async()
        {
            // Create a new kernel builder, and add AI services to it.
            // Add: OpenAI Chat Completion service.
            var builder = Kernel.CreateBuilder()
                .AddOpenAIChatCompletion(
                    modelId: "gpt-4o-mini",
                    apiKey: OPENAI_APIKEY,
                    httpClient: HttpLogger.GetHttpClient(true));

            // Add a chat completion plugin to the builder.
            builder.Plugins.AddFromType<EventSchedulerPlugins>();

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
                Find a 30 min slot for a run tomorrow morning.
                Book it in my calendar, please.
                """,
                new(settings)));
        }



        public class EventSchedulerPlugins
        {
            [KernelFunction("check_event")]
            [Description("check the scheduled events in specified day.")]
            public string[] CheckEvents(
                [Description("specified the date")] DateTime date )
            {
                return new string[] {
                    $"{date.Date:yyyy-MM-dd} 07:00 ~ 08:00 梳洗，準備早餐",
                    $"{date.Date:yyyy-MM-dd} 08:00 ~ 09:00 吃早餐",
                    $"{date.Date:yyyy-MM-dd} 09:30 ~ 10:00 通勤，開車上班",
                    $"{date.Date:yyyy-MM-dd} 10:00 ~ 11:00 跟 John 開會"
                };
            }

            [KernelFunction("add_event")]
            [Description("add event to my calendar, if no conflict, return success. ")]
            public string AddEvent(
                [Description("start datetime")]   DateTime since, 
                [Description("end datetime")]   DateTime until, 
                [Description("event description")]   string eventDescription)
            {
                return "success";
            }

            [KernelFunction("get_current_datetime")]
            [Description("Get the current date and time")]
            public DateTime GetCurrentTime()
            {
                return DateTime.Now;
            }

        }
    }

}
