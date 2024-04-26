using Microsoft.AspNetCore.Components;
using UserManagement.DTO.ModelsDTO;
using UserManagement.Web.Services;

namespace UserManagement.Web.Pages.Base
{
    public class ListEmployeeTableBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<EmployeesDTO> Employees { get; set; }

    }
}
