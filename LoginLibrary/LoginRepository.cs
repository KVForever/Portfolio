using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using DataEntities;
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
        public bool Login(UserLogins login)
        {
            var attempt = _DbContext.UserLogins.FirstOrDefault(x => x.UserName.Equals(login.UserName) && x.Password.Equals(login.Password));

            if(attempt != null)
            {
                return true;
            }
            return false;
        }
    }
}
