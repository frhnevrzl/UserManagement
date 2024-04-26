using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using UserManagement.DTO.ModelsDTO;
using UserManagement.Web.Services.Interfaces;

namespace UserManagement.Web.Pages.Base
{
    public class AddEmployeeBase : ComponentBase
    {
        [Inject]
        public IEmployeeServices EmployeeServices { get; set; }
        [Inject]
        public IDepartmentServices DepartmentServices { get; set; }

        public PostEmployeesDTO PostEmployees = new PostEmployeesDTO();
        public IEnumerable<DepartmentDTO> Department { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Department = await DepartmentServices.GetListDepartment();
        }
        public async Task OnClickAdd(PostEmployeesDTO postEmployeesDTO)
        {
            try
            {
                var addEmployeeDto = await EmployeeServices.PostEmployee(postEmployeesDTO);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
