using System.Runtime.Loader;

namespace DynamicLoadAndExecute.Console;

public class DemoAssemblyLoadContext: AssemblyLoadContext
{
    private readonly AssemblyDependencyResolver _resolver;

    public DemoAssemblyLoadContext(string mainAssemblyToLoadPath)
    {
        _resolver = new AssemblyDependencyResolver(mainAssemblyToLoadPath);
    }
}