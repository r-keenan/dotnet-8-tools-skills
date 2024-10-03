using Microsoft.SemanticKernel;

Settings? settings = GetSettings();
if (settings is null)
{
  WriteLine("Settings not found or not valid. Exiting the app.");
  return;
}

Kernel kernel = GetKernal(settings);

ConsoleKey key = ConsoleKey.A;

while (key is not ConsoleKey.X)
{
  Write("Write your question: ");
  string? question = ReadLine();
  WriteLine(await kernel.InvokePromptAsync(question));
  WriteLine();
  WriteLine("Press X to exit or any other key to ask a question.");
  key = ReadKey(intercept: true).Key;
}
