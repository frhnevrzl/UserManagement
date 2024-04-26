using Microsoft.AspNetCore.Components;
using UserManagement.DTO.ModelsDTO;
using UserManagement.Web.Services.Interfaces;

namespace UserManagement.Web.Pages
{
    public class EmployeesBase : ComponentBase
    {
        [Inject]
        public IEmployeeServices EmployeeServices { get; set; }

        public IEnumerable<EmployeesDTO> Employees { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Employees = await EmployeeServices.GetEmployees();
        }

        protected async Task DeleteEmployees(string empNum)
        {
            var empData = await EmployeeServices.DeleteEmployee(empNum);

        }
    }
}
