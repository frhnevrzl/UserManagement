using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.API.Extensions;
using UserManagement.API.Repositories.Interfaces;
using UserManagement.DTO.ModelsDTO;

namespace UserManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        protected IDepartmentRepository departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        [HttpGet]
        //[Route("Get")]
        public async Task<ActionResult<IEnumerable<DepartmentDTO>>> Get()
        {
            try
            {
                var DepartmentData = await this.departmentRepository.GetDepartment();

                var result = DepartmentData.DepartmentDTOConversion();
                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "No Data or Error Retrieving Data");
            }
        }
    }
}
