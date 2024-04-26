using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.DTO.ModelsDTO
{
    public class UnitDTO
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentNama { get; set; }
    }

    public class PostUnitDTO
    {
        public string Nama { get; set; }
        public int DepartmentId { get; set; }
    }

    public class UpdateUnitDTO
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public int DepartmentId { get; set; }
    }
}
