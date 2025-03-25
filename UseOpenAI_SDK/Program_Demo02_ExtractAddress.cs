using OpenAI.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace UseOpenAI_SDK
{
    internal partial class Program
    {

        static void Demo02_ExtractAddress_JsonObject()
        {
            // https://github.com/openai/openai-dotnet/blob/main/examples/Chat/Example06_StructuredOutputs.cs

            ChatClient client = new(
                "gpt-4o-mini",
                OPENAI_APIKEY);

            List<ChatMessage> messages =
            [
                new SystemChatMessage("Extract the address from the following text, Response using the following json format: { 'street_address'?: string, 'city'?: string, 'postal_code'?: string, 'country'?: string }"),
                new UserChatMessage("'- For the tea shop in Paris there is a good one on rue montorgueil.\n- You remember the number?\n- 90, I guess.'")
            ];

            ChatCompletionOptions options = new()
            {
                ResponseFormat = ChatResponseFormat.CreateJsonObjectFormat()
            };

            ChatCompletion completion = client.CompleteChat(messages, options);

            using JsonDocument structuredJson = JsonDocument.Parse(completion.Content[0].Text);

            Console.WriteLine($"Extract Address:");
            Console.WriteLine($"- street_address: {structuredJson.RootElement.GetProperty("street_address")}");
            Console.WriteLine($"- city:           {structuredJson.RootElement.GetProperty("city")}");
            //Console.WriteLine($"- postal_code:    {structuredJson.RootElement.GetProperty("postal_code")}");
            Console.WriteLine($"- country:        {structuredJson.RootElement.GetProperty("country")}");

        }



        static void Demo02_ExtractAddress_JsonSchema()
        {
            // https://platform.openai.com/docs/guides/structured-outputs?lang=curl
            // https://github.com/openai/openai-dotnet/blob/main/examples/Chat/Example06_StructuredOutputs.cs

            ChatClient client = new(
                "gpt-4o-mini", 
                OPENAI_APIKEY);

            List<ChatMessage> messages =
            [
                new SystemChatMessage("Extract the address from the following text:"),
                new UserChatMessage("'- For the tea shop in Paris there is a good one on rue montorgueil.\n- You remember the number?\n- 90, I guess.'")
            ];

            ChatCompletionOptions options = new()
            {
                ResponseFormat = ChatResponseFormat.CreateJsonSchemaFormat(
                    jsonSchemaFormatName: "address",
                    jsonSchema: BinaryData.FromBytes("""
                      {
                        "type": "object",
                        "properties":
                        {
                          "street_address":
                          {
                            "type": "string",
                            "description": "Number and name of the street address."
                          },
                          "city":
                          {
                            "type": "string",
                            "description": "Name of the city."
                          },
                          "postal_code":
                          {
                            "type": "string",
                            "description": "Postal or ZIP code."
                          },
                          "country":
                          {
                            "type": "string",
                            "description": "Name of the country."
                          }
                        },
                        "required": ["street_address", "city", "postal_code", "country"],
                        "additionalProperties": false
                      }
                    """u8.ToArray()),
                    jsonSchemaIsStrict: true)
            };

            ChatCompletion completion = client.CompleteChat(messages, options);

            using JsonDocument structuredJson = JsonDocument.Parse(completion.Content[0].Text);

            Console.WriteLine($"Extract Address:");
            Console.WriteLine($"- street_address: {structuredJson.RootElement.GetProperty("street_address")}");
            Console.WriteLine($"- city:           {structuredJson.RootElement.GetProperty("city")}");
            Console.WriteLine($"- postal_code:    {structuredJson.RootElement.GetProperty("postal_code")}");
            Console.WriteLine($"- country:        {structuredJson.RootElement.GetProperty("country")}");
        }



    }
}
