using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace UseMicrosoft_SemanticKernel
{
    internal partial class Program
    {


        static async Task Demo02_ExtractAddress_Async()
        {
            // Create a new kernel builder, and add AI services to it.
            // Add: OpenAI Chat Completion service.
            var builder = Kernel.CreateBuilder()
                .AddOpenAIChatCompletion(
                    modelId: "gpt-4o-mini",
                    apiKey: OPENAI_APIKEY,
                    httpClient: HttpLogger.GetHttpClient(true));

            var kernel = builder.Build();
            var settings = new OpenAIPromptExecutionSettings()
            {
                ResponseFormat = typeof(Address)
            };

            var result = await kernel.InvokePromptAsync(
                """
                <message role="system">
                    Extract the address from the following text.
                </message>
                <message role="user">
                    - For the tea shop in Paris there is a good one on rue montorgueil.
                    - You remember the number?
                    - 90, I guess.
                </message>
                """,
                new(settings));


            var address = JsonSerializer.Deserialize<Address>(result.ToString());

            Console.WriteLine($"Extract the Address from conversation:");
            Console.WriteLine($"- Street: {address.Street}");
            Console.WriteLine($"- City: {address.City}");
            Console.WriteLine($"- Postal Code: {address.PostalCode}");
            Console.WriteLine($"- Country: {address.Country}");
        }


        public class Address
        {
            [JsonPropertyName("street_address")]
            public string Street { get; set; }

            [JsonPropertyName("city")]
            public string City { get; set; }

            [JsonPropertyName("country")]
            public string Country { get; set; }

            [JsonPropertyName("postal_code")]
            public string PostalCode { get; set; }
        }

    }
}
