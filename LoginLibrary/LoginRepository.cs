﻿using DataEntities;
using Microsoft.AspNetCore.Identity;
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

        public async Task<User> GetUserByUsername(string username)
        {
            var result = await _DbContext.Users.Where(u => u.Username == username && !u.IsDeleted)
                .Include(u => u.Roles)
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<User> CreateAccount(User user)
        {
            user.DateCreated = DateTime.Now;
            user.DateModified = DateTime.Now;

            user.Roles.Clear();
            foreach(var role in user.Roles)
            {
                user.Roles.Add(await _DbContext.Roles.Where(r => r.Id == role.Id).FirstAsync());
            }
            

            _DbContext.Users.Add(user);
            await _DbContext.SaveChangesAsync();

            return user;
        }
        
    }
}