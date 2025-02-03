using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Game.Scripts.Encryption
{
    public static class AesEncryptionHelper
    {
        private static readonly string Key = "6F3D8A4B1C9E2F7D5G6H8J9K0L1M3N4O"; 
        private static readonly string IV = "A7B6C5D4E3F2G1H0";       
        
        public static string Encrypt(string plainText)
        {
            using Aes aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(Key);
            aes.IV = Encoding.UTF8.GetBytes(IV);

            using MemoryStream memoryStream = new();
            using CryptoStream cryptoStream = new(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
            using (StreamWriter writer = new(cryptoStream))
            {
                writer.Write(plainText);
            }

            return Convert.ToBase64String(memoryStream.ToArray());
        }

        public static string Decrypt(string cipherText)
        {
            using Aes aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(Key);
            aes.IV = Encoding.UTF8.GetBytes(IV);

            using MemoryStream memoryStream = new(Convert.FromBase64String(cipherText));
            using CryptoStream cryptoStream = new(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read);
            using StreamReader reader = new(cryptoStream);
            {
                return reader.ReadToEnd();
            }
        }
    }
}