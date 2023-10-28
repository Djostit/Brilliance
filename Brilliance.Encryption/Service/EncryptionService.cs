using Brilliance.Encryption.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Brilliance.Encryption.Service
{
    internal class Encryption : IEncryption
    {
        private readonly byte[] encryptionKey = Convert.FromBase64String(Properties.Resources.Key);
        public string DecryptData(byte[] encryptedData)
        {
            using Aes aes = Aes.Create();
            aes.Key = encryptionKey;

            byte[] iv = new byte[aes.IV.Length];
            byte[] encrypted = new byte[encryptedData.Length - iv.Length];

            Array.Copy(encryptedData, iv, iv.Length);
            Array.Copy(encryptedData, iv.Length, encrypted, 0, encrypted.Length);

            aes.IV = iv;

            using ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            byte[] decrypted = decryptor.TransformFinalBlock(encrypted, 0, encrypted.Length);
            return Encoding.UTF8.GetString(decrypted);
        }

        public byte[] EncryptData(string data)
        {
            using Aes aes = Aes.Create();
            aes.Key = encryptionKey;
            aes.GenerateIV();

            byte[] encrypted;

            using (ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
            {
                byte[] dataBytes = Encoding.UTF8.GetBytes(data);
                encrypted = encryptor.TransformFinalBlock(dataBytes, 0, dataBytes.Length);
            }

            byte[] result = new byte[aes.IV.Length + encrypted.Length];
            Array.Copy(aes.IV, result, aes.IV.Length);
            Array.Copy(encrypted, 0, result, aes.IV.Length, encrypted.Length);

            return result;
        }
    }
}
