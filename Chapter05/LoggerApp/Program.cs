using Microsoft.Extensions.Logging;

using ILoggerFactory factory = LoggerFactory.Create(builder =>
{
    builder.AddConsole();
});

// The generic type parameter is used to categorize log messages
ILogger logger = factory.CreateLogger<Program>();

string[] messageTemplates =
{
    "Logging is {Description}",
    "Product ID: {ProductId}, Produce name: {ProductName}"
};

logger.LogInformation(
    message: messageTemplates[0],
    args: "cool!");

logger.LogWarning(messageTemplates[1], 1, "Chai");