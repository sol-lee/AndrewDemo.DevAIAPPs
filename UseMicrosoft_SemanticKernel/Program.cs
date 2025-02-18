using Microsoft.Extensions.Configuration;

namespace UseMicrosoft_SemanticKernel
{
    internal class Program
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

            //Example01_SimpleChat();
            //Example03_FunctionCalling();
            //Example06_StructuredOutputs();
        }
    }
}
