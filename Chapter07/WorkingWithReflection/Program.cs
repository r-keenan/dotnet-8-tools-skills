using System.Reflection;

Console.WriteLine("Assembly metadata:");
Assembly? assembly = Assembly.GetEntryAssembly();

if (assembly is null)
{
    Console.WriteLine("Failed to get entry assembly.");
    return;
}

Console.WriteLine($"    Full name: {assembly.FullName}");
Console.WriteLine($"    Location: {assembly.Location}");
Console.WriteLine($"    Entry point: {assembly.EntryPoint?.Name}");

IEnumerable<Attribute> attributes = assembly.GetCustomAttributes();
Console.WriteLine($"    Assembly-level attributes:");
foreach (Attribute a in attributes)
{
   Console.WriteLine($"     {a.GetType()}");
}