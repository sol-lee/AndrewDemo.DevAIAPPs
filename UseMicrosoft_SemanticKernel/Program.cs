using Microsoft.Extensions.Configuration;


namespace UseMicrosoft_SemanticKernel
{
    internal partial class Program
    {
        private static string OPENAI_APIKEY = null;
        private static string OPENAI_ORGID = null;

        static async Task Main(string[] args)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();

            OPENAI_APIKEY = config["OpenAI:ApiKey"];
            OPENAI_ORGID = config["OpenAI:OrgId"];

            //await Demo02_ExtractAddress_Async();
            await Demo03_ScheduleEvent_Async();


            //await Example01_SimpleChatAsync();            
            //await Example03_FunctionCalling_ChatCompletion_Async();
            //await Example03_FunctionCalling_PromptTemplate_Async();
            //await Example03_FunctionCalling_PromptTemplate2_Async();
            //await Example06_StructuredOutputs_JsonObject_Async();
            //await Example06_StructuredOutputs_JsonSchema_Async();
        }
    }


}
