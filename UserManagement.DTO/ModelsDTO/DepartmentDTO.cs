using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.DTO.ModelsDTO
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        public string Nama { get; set; }
    }

    public class PostDepartmentDTO
    {
        public string Nama { get; set; }
    }

    public class UpdateDepartmentDTO
    {
        public int Id { get; set; }
        public string Nama { get; set; }
    }
}
