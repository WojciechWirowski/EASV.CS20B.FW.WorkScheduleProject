using System.Security.Cryptography;
using System.Text;

namespace EASV.CS20B.FW.WorkScheduleProject.Database.Security.Encryption
{
    public class MyRsaEncryptionService
    {
        private RSACryptoServiceProvider _rsa;
        private bool _hasPublicKey;
        private bool _hasPrivateKey;

        /// <summary>
        /// Creates our RSA encryption service. It gets initialized with a random Key pair.
        /// </summary>
        public MyRsaEncryptionService()
        {
            _rsa = new RSACryptoServiceProvider();
            _rsa.KeySize = 1024;
            _rsa.PersistKeyInCsp = true;
            _hasPublicKey = true;
            _hasPrivateKey = !_rsa.PublicOnly;
        }

        /// <summary>
        /// Creates our RSA encryption service using the given RSA parameters as an XML string
        /// </summary>
        /// <param name="rsaParams">The RSA parameters as an XML string</param>
        public MyRsaEncryptionService(string rsaParams)
        {
            _rsa = new RSACryptoServiceProvider();
            _rsa.FromXmlString(rsaParams);
            _hasPublicKey = true;
            _hasPrivateKey = !_rsa.PublicOnly;
        }

        /// <summary>
        /// Creates our RSA encryption service using the given CspParameters
        /// </summary>
        /// <param name="cspp">The CSP (Crypt Service Provider) parameters to use when creating the internal RSA Crypto Service Provider</param>
        public MyRsaEncryptionService(CspParameters cspp)
        {
            _rsa = new RSACryptoServiceProvider(cspp);
            _rsa.PersistKeyInCsp = true;
            _hasPublicKey = true;
            _hasPrivateKey = !_rsa.PublicOnly;
        }

        /// <summary>
        /// Encrypts a message using the internal RSA Crypto Service Provider
        /// </summary>
        /// <param name="message">The plaintext message to encrypt</param>
        /// <returns>The encrypted message as a byte[]</returns>
        public byte[] encryptMessage(string message)
        {
            byte[] clearText = Encoding.UTF8.GetBytes(message);
            byte[] enccryptedBytes = _rsa.Encrypt(clearText, RSAEncryptionPadding.Pkcs1);
            return enccryptedBytes;
        }

        /// <summary>
        /// Decrypt the message using the internal RSA Crypto Service Provider
        /// </summary>
        /// <param name="message">The encrypted message to decrypt</param>
        /// <returns>The decrypted message as a string</returns>
        public string decryptMessage(byte[] message)
        {
            byte[] clearBytes = _rsa.Decrypt(message, RSAEncryptionPadding.Pkcs1);
            string clearText = Encoding.UTF8.GetString(clearBytes);
            return clearText;
        }

        /// <summary>
        /// Gets the public key (RSAParameters) as an XML string
        /// </summary>
        /// <returns>The public key as an XML string</returns>
        public string GetPublicRsaParameters()
        {
            return _rsa.ToXmlString(false); //The false parameter excludes the private key
        }

        /// <summary>
        /// Gets the public and private keys (RSAParameters) as an XML string
        /// </summary>
        /// <returns>The public and private keys as an XML string</returns>
        public string GetPublicAndPrivateRsaParameters()
        {
            return _rsa.ToXmlString(true); //The true parameter includes the private key
        }
    }
}