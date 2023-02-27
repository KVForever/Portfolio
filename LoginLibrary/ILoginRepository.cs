using DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginLibrary
{
    public interface ILoginRepository
    {
        public bool Login(Users login);

        public string Hash(string input);

        public bool Verify(string input, string HashString);

        public void CreateAccount(Users user);
    }
}
