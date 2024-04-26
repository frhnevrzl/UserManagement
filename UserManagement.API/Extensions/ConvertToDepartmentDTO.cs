using UserManagement.API.Entity;
using UserManagement.DTO.ModelsDTO;

namespace UserManagement.API.Extensions
{
    public static class ConvertToDepartmentDTO
    {
        public static IEnumerable<DepartmentDTO> DepartmentDTOConversion(this IEnumerable<Department> departments)
        {
            return (from department in departments
                    select new DepartmentDTO
                    {
                        Id = department.Id,
                        Nama = department.Nama,
                    });
        }
    }
}
