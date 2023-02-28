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
        public bool Login(User login);

        //public string Hash(string input);

        //public bool Verify(string input);

        public void CreateAccount(User user);
    }
}
