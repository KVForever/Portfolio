using DataEntities;
using Microsoft.EntityFrameworkCore;

namespace LoginLibrary
{
    public class LoginRepository: ILoginRepository
    {
        public readonly PortfolioContext _DbContext;

        public LoginRepository(PortfolioContext dbContext)
        {
            _DbContext = dbContext;
        }

        //public async Task<User> GetUserByUsername(string username)
        //{
        //    var result = await _DbContext.Users.Where(u => u.Username == username && !u.IsDeleted)
        //        .Include(u => u.Roles)
        //        .FirstOrDefaultAsync();

        //    return result;
        //}

        public bool Login(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException("user");
            }

            var check = _DbContext.Users.FirstOrDefault(u => u.Password == user.Password && u.Username == user.Username);

            if(check != null)
            {
                return true;
            }

            return false;
        }

        public void CreateAccount(User user)
        {
            _DbContext.Users.Add(user);
            _DbContext.SaveChanges();
        }
        
    }
}
