using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata;
using UserManagement.API.Repositories;
using UserManagement.API.Repositories.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace UserManagement.API.CollectionServices
{
    public static class InternalServicesExtensions
    {
        public static IServiceCollection ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IEmployeesRepository, EmployeesRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IWorkingUnitRepository, WorkingUnitRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();

            return services;
        }
    }
}
