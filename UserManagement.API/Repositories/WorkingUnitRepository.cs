using Microsoft.EntityFrameworkCore;
using UserManagement.API.Data;
using UserManagement.API.Entity;
using UserManagement.API.Repositories.Interfaces;

namespace UserManagement.API.Repositories
{
    public class WorkingUnitRepository : IWorkingUnitRepository
    {
        protected AppDbContext appDbContext;
        protected IWorkingUnitRepository repos;

        public WorkingUnitRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<WorkingUnit>> GetUnit()
        {
            var data = await this.appDbContext.WorkingUnits.ToListAsync();
            return data;
        }

        public async Task<WorkingUnit> GetUnit(int id)
        {
            var data = await this.appDbContext.WorkingUnits.SingleOrDefaultAsync(x => x.Id == id);
            return data;
        }
    }
}
