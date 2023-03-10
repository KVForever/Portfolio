using DataEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginLibrary
{
    public class RoleRepository
    {
        private readonly PortfolioContext _dbContext;

        public RoleRepository(PortfolioContext dbContext)
        {
            _dbContext = dbContext;
        }   

        public async Task<List<Role>> GetAllRoles()
        {
            var result = await _dbContext.Roles
                .ToListAsync();

            return result;

        }
    }
}
