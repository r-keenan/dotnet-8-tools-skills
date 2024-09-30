using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace CryptographyLib;

public static class Protector
{
   // Salt size must be at least 8 bytes, using 16 bytes.
   private static readonly byte[] salt = Encoding.Unicode.GetBytes("7APPLES");

   // Default iterations for Rfc2898DeriveBytes is 1000.
   // Iterations should be high enough to take at least 100ms to
   // generate a Key and IV on the target machine. 150,000 iterations
   // takes 139ms on my 11th Gen Intel Core i7-1165G7 @ 2.80GHz.
   private static readonly int iterations = 150_000;

   public static string Encrypt(string plainText, string password)
   {
      byte[] encryptedBytes;
      byte[] plainBytes = Encoding.Unicode.GetBytes(plainText);

      using (Aes aes = Aes.Create()) // abstract factory method
      {
          Stopwatch timer = Stopwatch.StartNew();
        // Record how long it takes to generate the Key and IV
          using (Rfc2898DeriveBytes pbkdf2 = new(password, salt, iterations, HashAlgorithmName.SHA256))
          {
              Console.WriteLine($"PBKDF2 algorithm: {pbkdf2.HashAlgorithm}, Iteration count: {pbkdf2.IterationCount:N0}");

              aes.Key = pbkdf2.GetBytes(32); // Set a 256-bit key
              aes.IV = pbkdf2.GetBytes(16); // Set a 128-bit key
          }

          timer.Stop();

          Console.WriteLine($"{timer.ElapsedMilliseconds:N0} milliseconds to generate Key and IV.");

          if (timer.ElapsedMilliseconds < 100)
          {
              ConsoleColor previousColor = Console.ForegroundColor;
              Console.ForegroundColor = ConsoleColor.Red;
              Console.WriteLine("WARNING: The elapsed time to generate the Key and IV " + "may bve too short to provide a secure encryption key.");
              Console.ForegroundColor = previousColor;
          }
          Console.WriteLine($"Encryption algorithm: {nameof(Aes)}-{aes.KeySize}, {aes.Mode} mode with {aes.Padding} padding.");

          using (MemoryStream ms = new())
          {
               using (ICryptoTransform transformer = aes.CreateEncryptor())
               {
                   using (CryptoStream cs = new(ms, transformer, CryptoStreamMode.Write))
                   {
                      cs.Write(plainBytes, 0, plainBytes.Length);

                      if (!cs.HasFlushedFinalBlock)
                      {
                          cs.FlushFinalBlock();
                      }
                   }
               }

               encryptedBytes = ms.ToArray();
          }
      }

      return Convert.ToBase64String(encryptedBytes);
   }

   public static string Decrypt(string cipherText, string password)
   {
       byte[] plainBytes;
       byte[] cryptoBytes = Convert.FromBase64String(cipherText);

       using (Aes aes = Aes.Create())
       {
           using (Rfc2898DeriveBytes pbkdf2 = new(password, salt, iterations, HashAlgorithmName.SHA256))
           {
               aes.Key = pbkdf2.GetBytes(32);
               aes.IV = pbkdf2.GetBytes(16);
           }

           using (MemoryStream ms = new())
           {
               using (ICryptoTransform transformer = aes.CreateDecryptor())
               {
                   using (CryptoStream cs = new(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                   {
                       cs.Write(cryptoBytes, 0, cryptoBytes.Length);

                       if (!cs.HasFlushedFinalBlock)
                       {
                           cs.FlushFinalBlock();
                       }
                   }
               }

               plainBytes = ms.ToArray();
           }
       }

       return Encoding.Unicode.GetString(plainBytes);
   }
}