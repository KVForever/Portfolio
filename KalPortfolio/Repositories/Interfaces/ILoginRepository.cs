using DataEntities;
using System.Threading.Tasks;

namespace LoginLibrary
{
    public interface ILoginRepository
    {
        public Task<User> GetUserByUsername(string username);

        public Task<User> CreateAccount(User user);
    }
}
