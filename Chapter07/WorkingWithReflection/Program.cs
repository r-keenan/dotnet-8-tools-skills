using System.Reflection;
using WorkingWithReflection;

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

AssemblyInformationalVersionAttribute? version = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();

Console.WriteLine($"    Version: {version?.InformationalVersion}");

AssemblyCompanyAttribute? company = assembly.GetCustomAttribute<AssemblyCompanyAttribute>();

Console.WriteLine($"    Company: {company?.Company}");

Console.WriteLine();

Console.WriteLine("* Types:");
Type[] types = assembly.GetTypes();

// Yes, I know this is a triple-nested for each. Just following the book
foreach (Type type in types)
{
   Console.WriteLine();
   Console.WriteLine($"Type: {type.FullName}");
   MemberInfo[] members = type.GetMembers();

   foreach (MemberInfo member in members)
   {
      ObsoleteAttribute? obsolete = member.GetCustomAttribute<ObsoleteAttribute>();

      Console.WriteLine($"{member.MemberType}: {member.Name} ({member.DeclaringType?.Name}) {(obsolete is null ? "" : "Obsolete " + obsolete.Message)}");

      IOrderedEnumerable<CoderAttribute> coders =
         member.GetCustomAttributes<CoderAttribute>().OrderByDescending(c => c.LastModified);


      foreach (CoderAttribute coder in coders)
      {
         Console.WriteLine($"-> Modified by {coder.Coder} on {coder.LastModified.ToShortDateString()}");
      }
   }

}