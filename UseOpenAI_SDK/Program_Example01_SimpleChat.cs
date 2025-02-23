using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using OpenAI.Chat;

namespace UseOpenAI_SDK
{
    internal partial class Program
    {
        static void Example01_SimpleChat()
        {
            // https://github.com/openai/openai-dotnet/blob/main/examples/Chat/Example01_SimpleChat.cs
            ChatClient client = new(
                "gpt-4o-mini",
                OPENAI_APIKEY);


            ChatCompletion completion = client.CompleteChat(
                [
                    ChatMessage.CreateSystemMessage(@"you are a tester, answer me what I ask you."),
                    ChatMessage.CreateUserMessage(@"Say: 'this is a test'.")
                ],
                new ChatCompletionOptions()
                {
                    Temperature = 0.2f
                });

            Console.WriteLine($"[ASSISTANT]: {completion.Content[0].Text}");
        }

    }
}
