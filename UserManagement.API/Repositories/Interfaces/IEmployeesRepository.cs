using UserManagement.API.Entity;
using UserManagement.DTO.ModelsDTO;

namespace UserManagement.API.Repositories.Interfaces
{
    public interface IEmployeesRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployees(string empNum);
        Task<Employee> PostEmployee(PostEmployeesDTO postEmployeesDTO);
        Task<Employee> UpdateEmployee(string empNum, PostEmployeesDTO postEmployeesDTO);
        Task<Employee> DeleteEmployee(string empNum);

    }
}
