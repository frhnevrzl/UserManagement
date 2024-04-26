using Microsoft.AspNetCore.Components;
using UserManagement.DTO.ModelsDTO;
using UserManagement.Web.Services.Interfaces;

namespace UserManagement.Web.Pages.Base
{
    public class EmployeeDetailBase : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }
        [Inject]
        public IEmployeeServices EmployeeServices { get; set; }
        public EmployeesDTO Employee { get; set; }
        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Employee = await EmployeeServices.GetEmployee(Id);
            }
            catch (Exception e)
            {

                ErrorMessage = e.Message;
            }
        }
    }
}
