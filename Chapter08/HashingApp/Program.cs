
using CryptographyLib;

Console.WriteLine("Registering Alice with Pa$$w0rd:");
User alice = Protector.Register("Alice", "Pa$$w0rd");

Console.WriteLine($"  Name: {alice.Name}");
Console.WriteLine($"  Salt: {alice.Salt}");
Console.WriteLine($"  Password (salted and hashed): {alice.SaltedHashedPassword}");
Console.WriteLine();

Console.Write("Enter a new user to register: ");
string? username = Console.ReadLine();
if (string.IsNullOrEmpty(username)) username = "Bob";

Console.Write($"Enter a password for {username}: ");
string? password = Console.ReadLine();
if (string.IsNullOrEmpty(password)) password = "Pa$$w0rd";

Console.WriteLine("Registering a new user:");
User newUser = Protector.Register(username, password);
Console.WriteLine($"  Name: {newUser.Name}");
Console.WriteLine($"  Salt: {newUser.Salt}");
Console.WriteLine($"  Password (salted and hashed): {newUser.SaltedHashedPassword}");
Console.WriteLine();

bool correctPassword = false;

while (!correctPassword)
{
    Console.Write("Enter a username to log in: ");
    string? loginUsername = Console.ReadLine();
    if (string.IsNullOrEmpty(loginUsername))
    {
        Console.WriteLine("Login username cannot be empty.");
        Console.Write("Press Ctrl+C to end or press ENTER to retry.");
        Console.ReadLine();
        continue; // Return to the while statement.
    }

    Console.Write("Enter a password to log in: ");
    string? loginPassword = Console.ReadLine();
    if (string.IsNullOrEmpty(loginPassword))
    {
        Console.WriteLine("Login password cannot be empty.");
        Console.Write("Press Ctrl+C to end or press ENTER to retry.");
        Console.ReadLine();
        continue;
    }

    correctPassword = Protector.CheckPassword(
        loginUsername, loginPassword);

    if (correctPassword)
    {
        Console.WriteLine($"Correct! {loginUsername} has been logged in.");
    }
    else
    {
        Console.WriteLine("Invalid username or password. Try again.");
    }
}