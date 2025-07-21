using System;
using System.Text;
namespace MachineNewGUI.JsonEncryption
{
    public static class XorJsonEncryption
    {
        private const string Key = "gsrrouter"; // 🔑 You can change this

        public static string Encrypt(string plainJson)
        {
            var keyBytes = Encoding.UTF8.GetBytes(Key);
            var jsonBytes = Encoding.UTF8.GetBytes(plainJson);
            var result = new byte[jsonBytes.Length];

            for (int i = 0; i < jsonBytes.Length; i++)
            {
                result[i] = (byte)(jsonBytes[i] ^ keyBytes[i % keyBytes.Length]);
            }

            return Convert.ToBase64String(result);
        }

        public static string Decrypt(string encryptedBase64)
        {
            var keyBytes = Encoding.UTF8.GetBytes(Key);
            var encryptedBytes = Convert.FromBase64String(encryptedBase64);
            var result = new byte[encryptedBytes.Length];

            for (int i = 0; i < encryptedBytes.Length; i++)
            {
                result[i] = (byte)(encryptedBytes[i] ^ keyBytes[i % keyBytes.Length]);
            }

            return Encoding.UTF8.GetString(result);
        }


    }
}