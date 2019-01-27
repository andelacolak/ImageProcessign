using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace API.Hashing_Algorithm
{
    public class HashWithSalt
    {
        public byte[] salt { get; private set; }
        public byte[] hash { get; private set; }

        public HashWithSalt(byte[] password)
        {
            salt = GetSalt();
            hash = GenerateSaltedHash(password);
        }

        private byte[] GenerateSaltedHash(byte[] password)
        {
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] passWithSaltBytes = CombineByteArrays(password, salt);

            return algorithm.ComputeHash(passWithSaltBytes);
        }

        private byte[] GetSalt()
        {
            var salt = new byte[64];
            using (var random = new RNGCryptoServiceProvider()) { random.GetNonZeroBytes(salt); }

            return salt;
        }

        private byte[] CombineByteArrays(byte[] first, byte[] second)
        {
            byte[] ret = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);

            return ret;
        }
    }
}