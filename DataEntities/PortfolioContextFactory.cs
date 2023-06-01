using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntities
{
    internal class PortfolioContextFactory : IDesignTimeDbContextFactory<PortfolioContext>
    {
        public PortfolioContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PortfolioContext>();
            optionsBuilder.UseSqlServer("Server=HBS-KVASSAR\\MSSQLSERVER01;Database=Portfolio;Integrated Security=True;Trusted_Connection=True;MultipleActiveResultSets=True;Encrypt=False;TrustServerCertificate=True;");
            return new PortfolioContext(optionsBuilder.Options);
        }
    }
}
