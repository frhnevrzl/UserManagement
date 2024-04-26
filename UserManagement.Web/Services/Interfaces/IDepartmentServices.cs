using UserManagement.DTO.ModelsDTO;

namespace UserManagement.Web.Services.Interfaces
{
    public interface IDepartmentServices
    {
        Task<IEnumerable<DepartmentDTO>> GetListDepartment();
    }
}
