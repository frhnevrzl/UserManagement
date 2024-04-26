using UserManagement.DTO.ModelsDTO;

namespace UserManagement.Web.Services.Interfaces
{
    public interface IEmployeeServices
    {
        Task<IEnumerable<EmployeesDTO>> GetEmployees();
        Task<EmployeesDTO> GetEmployee(string empNum);
        Task<EmployeesDTO> DeleteEmployee(string empNum);
        Task<EmployeesDTO> PostEmployee(PostEmployeesDTO postEmployeesDTO);
    }
}
