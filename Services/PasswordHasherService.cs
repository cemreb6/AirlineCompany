using System.Security.Cryptography;

namespace AirlineCompany.Services
{
    public static class PasswordHasherService
    {
        private const int SaltSize = 16; // in bytes
        private const int HashSize = 20; // in bytes
        private const int Iterations = 10000; // number of times to apply the hashing function

        public static byte[] GenerateSalt()
        {
            byte[] salt = new byte[SaltSize];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        public static byte[] GenerateHash(string password, byte[] salt)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA1))
            {
                return pbkdf2.GetBytes(HashSize);
            }
        }
        public static bool VerifyPassword(string password, byte[] salt, byte[] hash)
        {
            byte[] computedHash;
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA1))
            {
                computedHash = pbkdf2.GetBytes(HashSize);
            }
            return İsEqual(hash, computedHash);
        }

        private static bool İsEqual(byte[] a, byte[] b)
        {
            uint diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
            {
                diff |= (uint)(a[i] ^ b[i]);
            }
            return diff == 0;
        }
    }
}
