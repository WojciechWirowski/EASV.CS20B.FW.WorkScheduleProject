using System;
using System.IO;
using System.Security.Cryptography;

namespace EASV.CS20B.FW.WorkScheduleProject.Database.Security.Encryption
{
    public class MyAesEncryptionService
    {
        private byte[] _key;
        private byte[] _iv;
        private AesCryptoServiceProvider _aes;

        public MyAesEncryptionService()
        {
            _aes = new AesCryptoServiceProvider();
            _key = _aes.Key;
            _iv = _aes.IV;
        }

        public MyAesEncryptionService(string key, string iv)
        {
            _key = Convert.FromBase64String(key);
            _iv = Convert.FromBase64String(iv);
            _aes = new AesCryptoServiceProvider();
            _aes.Key = _key;
            _aes.IV = _iv;
        }

        public MyAesEncryptionService(byte[] key, out byte[] iv)
        {
            _key = key;
            _aes = new AesCryptoServiceProvider();
            _aes.Key = _key;
            _aes.GenerateIV();
            _iv = iv = _aes.IV;
        }
        
        public MyAesEncryptionService(byte[] key, byte[] iv)
        {
            _key = key;
            _iv = iv;
            _aes = new AesCryptoServiceProvider();
            _aes.Key = _key;
            _aes.IV = _iv;
        }

        public byte[] EncryptMessage(string message)
        {
            byte[] encrypted;

            ICryptoTransform encryptor = _aes.CreateEncryptor();
            // Create the streams used for encryption.
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        //Write all data to the stream.
                        swEncrypt.Write(message);
                    }

                    encrypted = msEncrypt.ToArray();
                    msEncrypt.Flush();
                }
            }
            
            return encrypted;
        }

        public string DecryptMessage(byte[] encryptedMessage)
        {
            string clearText;
            //Decryption
            ICryptoTransform decrypter = _aes.CreateDecryptor();
            using (MemoryStream msDecrypt = new MemoryStream(encryptedMessage)) //Remember that encrypted is a byte[]
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decrypter, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        clearText = srDecrypt.ReadToEnd();
                    }
                }
            }

            return clearText;
        }

        public string GetKey()
        {
            return Convert.ToBase64String(_key);
        }

        public string GetIV()
        {
            return Convert.ToBase64String(_iv);
        }
        
    }
}