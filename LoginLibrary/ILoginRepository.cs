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
        public Task<User> GetUserByUsername(string username);

        public Task<User> CreateAccount(User user);
    }
}
