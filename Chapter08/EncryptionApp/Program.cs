using System.Security.Cryptography;
using CryptographyLib;

Console.Write("Enter a message that you want to encrypt: ");
string? message = Console.ReadLine();

Console.Write("Enter password: ");
string? password = Console.ReadLine();

if ((password is null) || (message is null))
{
    Console.WriteLine("Message or password cannot be null.");
    return;
}

string cipherText = Protector.Encrypt(message, password);

Console.WriteLine($"Encrypted text: {cipherText}");

Console.Write("Enter the password: ");
string? passwordToDecrypt = Console.ReadLine();

if (passwordToDecrypt is null)
{
    Console.WriteLine("Pass to decrypt cannot be null.");
    return;
}

try
{
    string clearText = Protector.Decrypt(cipherText, passwordToDecrypt);
    Console.WriteLine($"Decrypted text: {clearText}");
}
catch (CryptographicException)
{
    Console.WriteLine("You entered the wrong password!");
}
catch (Exception ex)
{
    Console.WriteLine($"Non-cryptographic exception: {ex.GetType().Name}, {ex.Message}");
}