using UserManagement.API.Entity;

namespace UserManagement.API.Repositories.Interfaces
{
    public interface IStatusRepository
    {
        Task<IEnumerable<EmployeeStatus>> GetEmployeeStatus();
        Task<EmployeeStatus> GetEmployeeStatus(int id);
    }
}
