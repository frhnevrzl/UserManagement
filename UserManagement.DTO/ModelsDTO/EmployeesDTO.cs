using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.DTO.ModelsDTO
{
    public class EmployeesDTO
    {
        public Guid Id { get; set; }
        public string EmployeeNumber { get; set; }
        public string Nama { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }

        public int UnitId { get; set; }
        public string? UnitName { get; set; }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public int StatusId { get; set; }
        public string? StatusName { get; set;}
    }

    public class PostEmployeesDTO
    {
        public string EmployeeNumber { get; set; }
        public string Nama { get; set; }
        public string Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public int UnitId { get; set; }
        public int StatusId { get; set; }
    }

    public class UpdateEmployeesDTO
    {
        public Guid Id { get; set; }
        public string Nama { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public int UnitId { get; set; }
        public int StatusId { get; set; }
    }
}
