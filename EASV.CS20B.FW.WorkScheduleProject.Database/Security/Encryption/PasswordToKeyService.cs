using System;
using System.Security.Cryptography;

namespace EASV.CS20B.FW.WorkScheduleProject.Database.Security.Encryption
{
    /// <summary>
    /// Class used to create Keys for encryption algorithms from passwords. This class is also suitable for the AES algorithm.
    /// Make sure that an appropriate key size is chosen. The larger the key size the more safe it is.
    /// However the size should fit the algorithm of choice.
    /// </summary>
    public class PasswordToKeyService
    {
        public byte[] GetKey(string password, out byte[] salt, int keyLength)
        {
            if (keyLength % 8 != 0)
                throw new ArgumentException("Key length must be a multiple of 8");

            using (var derivedBytes = new Rfc2898DeriveBytes(password, keyLength))
            {
                salt = derivedBytes.Salt;
                return derivedBytes.GetBytes(keyLength / 8);
            }
        }

        public byte[] GetKey(string password, byte[] salt, int keyLength)
        {
            if (keyLength % 8 != 0)
                throw new ArgumentException("Key length must be a multiple of 8");

            using (var derivedBytes = new Rfc2898DeriveBytes(password, salt))
            {
                return derivedBytes.GetBytes(keyLength / 8);
            }
        }
    }
}