﻿using KalPortfolio.Repositories.Interfaces;
using DataEntities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KalPortfolio.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        public readonly PortfolioContext _dbContext;
        public AdminRepository(PortfolioContext dbContext)
        {
            _dbContext = dbContext;
        } 

        public async Task<IEnumerable<User>> GetAdmins()
        {
            var admin = await _dbContext.Roles.Where(r => r.Name.Equals("Admin")).SelectMany(r => r.Users).Where(x => x.IsDeleted == false).ToListAsync();

            return admin;
        }

        public async Task<bool> DeleteAdmin(int id)
        {
            var toDelete = await _dbContext.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
            
            if(toDelete != null)
            {
                toDelete.IsDeleted = true;
                await _dbContext.SaveChangesAsync(); ;
            }
            return true;
        }
    }
}
