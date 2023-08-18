using System.Security.Cryptography;
using System.Text;

namespace MealOrdering.Client.Utils
{
    public class PasswordManager
    {

        public static string Encrypt(string plainText, string key, string iv)
        {
            using Aes aesAlg = Aes.Create();
            aesAlg.Key = Encoding.UTF8.GetBytes(key);
            aesAlg.IV = Encoding.UTF8.GetBytes(iv);

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using var memoryStream = new System.IO.MemoryStream();
            using var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            using var streamWriter = new System.IO.StreamWriter(cryptoStream);

            streamWriter.Write(plainText);
            streamWriter.Flush();
            cryptoStream.FlushFinalBlock();
            memoryStream.Flush();

            return Convert.ToBase64String(memoryStream.ToArray());
        }

        public static string Decrypt(string cipherText, string key, string iv)
        {
            using Aes aesAlg = Aes.Create();
            aesAlg.Key = Encoding.UTF8.GetBytes(key);
            aesAlg.IV = Encoding.UTF8.GetBytes(iv);

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using var memoryStream = new System.IO.MemoryStream(Convert.FromBase64String(cipherText));
            using var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            using var streamReader = new System.IO.StreamReader(cryptoStream);

            return streamReader.ReadToEnd();
        }

    }
}
