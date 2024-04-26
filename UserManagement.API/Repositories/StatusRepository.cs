using Microsoft.EntityFrameworkCore;
using UserManagement.API.Data;
using UserManagement.API.Entity;
using UserManagement.API.Repositories.Interfaces;

namespace UserManagement.API.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        protected AppDbContext appDbContext;

        public StatusRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<EmployeeStatus>> GetEmployeeStatus()
        {
            var data = await this.appDbContext.EmployeeStatuses.ToListAsync();
            return data;
        }

        public async Task<EmployeeStatus> GetEmployeeStatus(int id)
        {
            var data = await this.appDbContext.EmployeeStatuses.SingleOrDefaultAsync(x => x.Id == id);
            return data;
        }
    }
}
