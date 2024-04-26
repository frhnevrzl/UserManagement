using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.DTO.ModelsDTO
{
    public class StatusEmployeeDTO
    {
        public int Id { get; set; }
        public string Nama { get; set; }
    }
    public class PostStatusEmployeeDTO
    {
        public string Nama { get; set; }
    }

    public class UpdateStatusEmployeeDTO
    {
        public int Id { get; set; }
        public string Nama { get; set; }
    }
}
