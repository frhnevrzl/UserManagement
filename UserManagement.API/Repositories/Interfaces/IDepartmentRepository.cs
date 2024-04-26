using UserManagement.API.Entity;

namespace UserManagement.API.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartment();
        Task<Department> GetDepartment(int id);

    }
}
