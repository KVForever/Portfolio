using DataEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
namespace LoginLibrary
{
    public class LoginRepository : ILoginRepository
    {
        public readonly PortfolioContext dbContext;

        public LoginRepository(PortfolioContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User> GetUserByUsername(string username)
        {
            var result = await dbContext.Users.Where(u => u.Username.Equals(username) && !u.IsDeleted)
                .Include(u => u.Roles)
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<User> CreateAccount(User user)
        {
            user.DateCreated = DateTime.Now;
            user.DateModified = DateTime.Now;

            var rolesToBeAssigned = new List<int>();

            foreach (var role in user.Roles)
            {
                rolesToBeAssigned.Add(role.Id);
            }

            user.Roles.Clear();

            foreach (var roleId in rolesToBeAssigned)
            {
                user.Roles.Add(await dbContext.Roles.Where(r => r.Id == roleId).FirstAsync());
            }

            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();

            return user;
        }

    }
}
