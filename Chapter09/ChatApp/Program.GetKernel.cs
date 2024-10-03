using Microsoft.SemanticKernel;

partial class Program
{
  private static Kernel GetKernal(Settings settings)
  {
	IKernelBuilder kernelBuilder = Kernel.CreateBuilder();

	// Configure the OpenAI chat with model and secret key.
	kernelBuilder.AddOpenAIChatCompletion(settings.ModelId, settings.OpenAISecretKey);

	Kernel kernel = kernelBuilder.Build();

	// Create a prompt function as part of a plugin and add it to the kernel
	kernel.ImportPluginFromFunctions(pluginName: "AuthorInformation",
	[
		kernel.CreateFunctionFromMethod(
		  method: GetAuthorBiography,
		  functionName: nameof(GetAuthorBiography),
		  description: "Gets the author's biography.")
	]);

	kernel.ImportPluginFromFunctions(pluginName: "NorthwindProducts", [
		kernel.CreateFunctionFromMethod(
		method: GetProductsInCategory,
		functionName: nameof(GetProductsInCategory),
		description: "Get the products in a category from the Northwind database."
		  )
	]);

	return kernel;
  }
}
