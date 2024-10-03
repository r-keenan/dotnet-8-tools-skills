using Microsoft.SemanticKernel;

partial class Program
{
  private static Kernel GetKernal(Settings settings)
  {
	IKernelBuilder kernelBuilder = Kernel.CreateBuilder();

	// Configure the OpenAI chat with model and secret key.
	kernelBuilder.AddOpenAIChatCompletion(settings.ModelId, settings.OpenAISecretKey);

	Kernel kernel = kernelBuilder.Build();

	return kernel;
  }
}
