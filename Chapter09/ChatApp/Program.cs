using System.Text;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel.Memory;

Settings? settings = GetSettings();
if (settings is null)
{
  WriteLine("Settings not found or not valid. Exiting the app.");
  return;
}

Kernel kernel = GetKernal(settings);

KernelFunction function = kernel.CreateFunctionFromPrompt("""
    Author biography: {{ authorInformation.getAuthorBiography }}.
    {{ $question }}
    """);

KernelArguments arguments = new();

ConsoleKey key = ConsoleKey.A;

IChatCompletionService completion = kernel.GetRequiredService<IChatCompletionService>();

ChatHistory history = new(systemMessage: "You are an AI assistant based on Mark J Price's knowledge, skills, and expertise.");

OpenAIPromptExecutionSettings options = new() { ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions };

// To help implement async streaming output.
StringBuilder builder = new();

while (key is not ConsoleKey.X)
{
  Write("Write your question: ");
  string? question = ReadLine();
  //WriteLine(await kernel.InvokePromptAsync(question));

  //arguments["question"] = question;

  // Call a single function
  //WriteLine(await function.InvokeAsync(kernel, arguments));
  history.AddUserMessage(question);

  builder.Clear();
  await foreach (StreamingChatMessageContent message in completion.GetStreamingChatMessageContentsAsync(history, options, kernel))
  {
    Write(message.Content);
    builder.Append(message.Content);
  }

  //ChatMessageContent answer = await completion.GetChatMessageContentAsync(history);

  //history.AddAssistantMessage(answer.Content!);
  history.AddAssistantMessage(builder.ToString());

  //WriteLine(answer.Content);

  WriteLine();
  WriteLine("Press X to exit or any other key to ask a question.");
  key = ReadKey(intercept: true).Key;
}
