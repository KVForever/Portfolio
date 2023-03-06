using DataEntities;

namespace LoginLibrary
{
    public class LoginRepository: ILoginRepository
    {
        public readonly PortfolioContext _DbContext;

        public LoginRepository(PortfolioContext dbContext)
        {
            _DbContext = dbContext;
        }


        public bool Login(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException("user");
            }

            var check = _DbContext.Users.FirstOrDefault(x => x.Password == user.Password && x.Username == user.Username);

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
