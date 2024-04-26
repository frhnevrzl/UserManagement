using Microsoft.EntityFrameworkCore;
using UserManagement.API.Data;
using UserManagement.API.Entity;
using UserManagement.API.Repositories.Interfaces;

namespace UserManagement.API.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        protected AppDbContext appDbContext;
        public DepartmentRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Department>> GetDepartment()
        {
            var data = await this.appDbContext.Departments.ToListAsync();
            return data;
        }

        public async Task<Department> GetDepartment(int id)
        {
            var data = await this.appDbContext.Departments.SingleOrDefaultAsync(x=>x.Id == id);
            return data;
        }
    }
}
