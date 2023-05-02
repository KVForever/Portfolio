using DataEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KalPortfolio.Repositories.Interfaces
{
    public interface IAdminRepository
    {
        public Task<IEnumerable<User>> GetAdmins();
        public Task<bool> DeleteAdmin(int id);
    }
}
