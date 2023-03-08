using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
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

        /*What is this doing*/
        public static bool OnlyInRole(this IPrincipal user, string role)
        {
            var roles = new List<string> { "Admin", "Dispatch", "Orders", "Account", "Scale" };
            return user.IsInRole(role) && roles.Where(x => x != role).All(r => !user.IsInRole(r));
        }

        public static string GenerateToken()
        {
            return GenerateRandomString();
        }

        public static string GenerateRandomString()
        {
            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            var data = new byte[1];
            var crypto = RandomNumberGenerator.Create();
            crypto.GetNonZeroBytes(data);
            data = new byte[SALT_SIZE];
            crypto.GetNonZeroBytes(data);
            var result = new StringBuilder(SALT_SIZE);
            foreach(var x in data)
            {
                result.Append(chars[x % (chars.Length)]);
            }
            return result.ToString();
        }
    }
}
