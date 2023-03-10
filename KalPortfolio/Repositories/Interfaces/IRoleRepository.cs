using DataEntities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginLibrary
{
    public interface IRoleRepository
    {
        public Task<List<Role>> GetAllRoles();
    }
}
