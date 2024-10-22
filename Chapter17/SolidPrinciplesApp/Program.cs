// See https://aka.ms/new-console-template for more information
using SolidPrinciplesApp;

Console.WriteLine("Hello, World!");

Document doc = new();
IPrinter printer = new MultiFunctionPrinter();
printer.Print(doc);
