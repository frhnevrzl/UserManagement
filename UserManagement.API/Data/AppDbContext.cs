using Microsoft.EntityFrameworkCore;
using UserManagement.API.Entity;

namespace UserManagement.API.Data
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<WorkingUnit> WorkingUnits { get; set; }
        public DbSet<EmployeeStatus> EmployeeStatuses { get; set; }

    }
}
