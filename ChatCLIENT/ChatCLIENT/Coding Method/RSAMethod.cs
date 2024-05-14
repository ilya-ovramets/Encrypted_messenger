using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ChatCLIENT.Coding_Method
{
    internal class RSAMethod : MessageHandler
    {
        private RSACryptoServiceProvider _rsaProvider;

        public string DMessage(string encryptMessage)
        {
            byte[] encryptedBytes = Convert.FromBase64String(encryptMessage);
            byte[] decryptedBytes = _rsaProvider.Decrypt(encryptedBytes, true);
            return Encoding.UTF8.GetString(decryptedBytes);
        }

        public string EncryptMessage(string message)
        {
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            byte[] encryptedBytes = _rsaProvider.Encrypt(messageBytes, true);
            return Convert.ToBase64String(encryptedBytes);
        }
    }
}
