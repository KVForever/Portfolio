using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DataEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LoginLibrary
{
    public class LoginRepository: ILoginRepository
    {
        public readonly PortfolioContext _DbContext;

        public LoginRepository(PortfolioContext dbContext)
        {
            _DbContext = dbContext;
        }

        public string Hash(string input)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(input, salt, 100000, HashAlgorithmName.SHA256, 32);
            const char segnmentDelimiter = ':';

            return String.Join(segnmentDelimiter, Convert.ToHexString(hash), Convert.ToHexString(salt), 100000, HashAlgorithmName.SHA256);
        }

        public bool Verify(string input, string HashString)
        {
            const char segmentDelimiter = ':';
            string[] segments = HashString.Split(segmentDelimiter);
            byte[] hash = Convert.FromHexString(segments[0]);
            byte[] salt = Convert.FromHexString(segments[1]);
            int iterations = int.Parse(segments[2]);
            HashAlgorithmName algorithm = new HashAlgorithmName(segments[3]);
            byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(input, salt, iterations, HashAlgorithmName.SHA256, hash.Length);

            return CryptographicOperations.FixedTimeEquals(inputHash, hash);
        }

        public void CreateAccount(Users user)
        {
            string hashed = Hash(user.PasswordHash);

            _DbContext.Add(hashed);
            _DbContext.Add(user.Id);
            _DbContext.Add(user.Email);
            _DbContext.Add(user.UserName);

            _DbContext.SaveChanges();

        }

        public bool Login(Users login)
        {
            string hashed = Hash(login.PasswordHash);

            bool isPasswordCorrect = Verify(login.PasswordHash, hashed);

            return isPasswordCorrect;
        }
    }
}
