using Microsoft.Extensions.Configuration;


namespace UseMicrosoft_SemanticKernel
{
    internal partial class Program
    {
        private static string OPENAI_APIKEY = null;
        private static string OPENAI_ORGID = null;

        static void Main(string[] args)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();

            OPENAI_APIKEY = config["OpenAI:ApiKey"];
            OPENAI_ORGID = config["OpenAI:OrgId"];

            //Example01_SimpleChatAsync().Wait();            
            //Example03_FunctionCallingAsync().Wait();
            //Example06_StructuredOutputs_JsonObject_Async().Wait();
            Example06_StructuredOutputs_JsonSchema_Async().Wait();
        }
    }


}
