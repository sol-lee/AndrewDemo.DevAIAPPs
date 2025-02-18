using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenAI.Chat;

namespace UseOpenAI_SDK
{
    internal partial class Program
    {
        static void Example01_SimpleChat()
        {
            // https://github.com/openai/openai-dotnet/blob/main/examples/Chat/Example01_SimpleChat.cs

            ChatClient client = new ChatClient(
                model: "gpt-4o",
                apiKey: OPENAI_APIKEY);

            //ChatCompletion completion = client.CompleteChat("Say 'this is a test.'");
            ChatCompletion completion = client.CompleteChat(
                GetChatMsgs(),
                new ChatCompletionOptions()
                {
                    Temperature = 0.2f
                });

            Console.WriteLine($"[ASSISTANT]: {completion.Content[0].Text}");
        }

        static IEnumerable<ChatMessage> GetChatMsgs()
        {
            yield return ChatMessage.CreateSystemMessage(@"you are a tester, answer me what I ask you.");
            yield return ChatMessage.CreateUserMessage(@"Say: 'this is a test'.");
        }
    }
}
