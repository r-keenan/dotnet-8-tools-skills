namespace WorkingWithReflection;

public class Animal
{
    [Coder("Ross Keenan", "30 September 2024")]
    [Coder("Mark Price", "22 June 2024")]

    [Obsolete($"use {nameof(NewSpeak)} instead.")]
    public void Speak()
    {
        Console.WriteLine("Woof...");
    }

    public void NewSpeak()
    {
        Console.WriteLine("Woooooooooooooof....");
    }
}