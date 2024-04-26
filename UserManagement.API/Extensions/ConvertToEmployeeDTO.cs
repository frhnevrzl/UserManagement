using UserManagement.API.Entity;
using UserManagement.DTO.ModelsDTO;

namespace UserManagement.API.Extensions
{
    public static class ConvertToEmployeeDTO
    {
        public static IEnumerable<EmployeesDTO> EmployeesDTOConversion(this IEnumerable<Employee> employees,
                                                                        IEnumerable<WorkingUnit> units,
                                                                        IEnumerable<Department> departments,
                                                                        IEnumerable<EmployeeStatus> status
                                                                        )
        {
            return (from employee in employees
                    join unit in units on employee.UnitId equals unit.Id
                    join dep in departments on unit.DepartmentId equals dep.Id
                    join stat in status on employee.StatusId equals stat.Id
                    select new EmployeesDTO
                    {
                        Id = employee.Id,
                        EmployeeNumber = employee.EmployeeNumber,
                        Nama = employee.Nama,
                        Email = employee.Email,
                        PhoneNumber = employee.PhoneNumber,
                        Address = employee.Address,
                        City = employee.City,
                        Country = employee.Country,
                        UnitId = employee.UnitId,
                        UnitName = unit.Nama,
                        DepartmentId = dep.Id,
                        DepartmentName = dep.Nama,
                        StatusId = stat.Id,
                        StatusName = stat.Nama
                    }).ToList();
        }

        public static EmployeesDTO EmployeesDTOConversion(this Employee employee,
                                                               WorkingUnit units,
                                                               Department departments,
                                                               EmployeeStatus status
                                                                )
        {
            return new EmployeesDTO
            {
                Id = employee.Id,
                Address = employee.Address,
                City = employee.City,
                Country = employee.Country,
                UnitId = employee.UnitId,
                DepartmentId = departments.Id,
                StatusId = employee.StatusId,
                DepartmentName = departments.Nama,
                EmployeeNumber = employee.EmployeeNumber,
                Nama = departments.Nama,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                StatusName = status.Nama,
                UnitName = units.Nama,
            };
        }
    }
}
