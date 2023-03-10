using DataEntities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoginLibrary
{
    public class RoleRepository: IRoleRepository
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
