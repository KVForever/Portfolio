using System;
using System.Security.Cryptography;
using System.Text;

namespace KalPortfolio.Helpers
{
    public static class UserHelper
    {
        private const int SALT_SIZE = 32;

        public static string GetHashedPassword(string password, string salt)
        {
            var passwordBytes = Encoding.Default.GetBytes(password);
            var saltBytes = Convert.FromBase64String(salt);

            var combined = new byte[passwordBytes.Length + saltBytes.Length];
            Array.Copy(passwordBytes, combined, passwordBytes.Length);
            Array.Copy(saltBytes, 0, combined, passwordBytes.Length, saltBytes.Length);

            var algorithm = SHA256.Create();
            var hash = algorithm.ComputeHash(combined);
            return Convert.ToBase64String(hash);
        }

        public static string GetSalt()
        {
            var rng = RandomNumberGenerator.Create();
            var buff = new byte[SALT_SIZE];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);    
        }

    }
}
