using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UserManagement.API.Extensions;
using UserManagement.API.Repositories.Interfaces;
using UserManagement.DTO.ModelsDTO;

namespace UserManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        protected IEmployeesRepository employeesRepository;
        protected IDepartmentRepository departmentRepository;
        protected IWorkingUnitRepository workingUnitRepository;
        protected IStatusRepository statusRepository;

        public EmployeesController(IEmployeesRepository employeesRepository, IDepartmentRepository departmentRepository, IWorkingUnitRepository workingUnitRepository, IStatusRepository statusRepository)
        {
            this.employeesRepository = employeesRepository;
            this.departmentRepository = departmentRepository;
            this.workingUnitRepository = workingUnitRepository;
            this.statusRepository = statusRepository;
        }

        [HttpGet("{empNum}")]
        //[Route("GetById")]
        public async Task<ActionResult<EmployeesDTO>> Get(string empNum)
        {
            try
            {

                var EmployeeData = await this.employeesRepository.GetEmployees(empNum);
                if (EmployeeData == null)
                {
                    return BadRequest();
                }
                else
                {
                    var UnitData = await this.workingUnitRepository.GetUnit(EmployeeData.UnitId);
                    var DepartmentData = await this.departmentRepository.GetDepartment(UnitData.DepartmentId);
                    var StatusData = await this.statusRepository.GetEmployeeStatus(EmployeeData.StatusId);

                    var result = EmployeeData.EmployeesDTOConversion(UnitData, DepartmentData, StatusData);
                    return Ok(result);
                }

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "No Data or Error Retrieving Data");
            }
        }

        [HttpGet]
        //[Route("Get")]
        public async Task<ActionResult<IEnumerable<EmployeesDTO>>> Get()
        {
            try
            {

                var EmployeeData = await this.employeesRepository.GetEmployees();
                var UnitData = await this.workingUnitRepository.GetUnit();
                var DepartmentData = await this.departmentRepository.GetDepartment();
                var StatusData = await this.statusRepository.GetEmployeeStatus();

                var result = EmployeeData.EmployeesDTOConversion(UnitData, DepartmentData, StatusData);
                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "No Data or Error Retrieving Data");
            }
        }

        [HttpPost]
        public async Task<ActionResult<EmployeesDTO>> Post([FromBody] PostEmployeesDTO postEmployeesDTO)
        {
            try
            {
                var newItem = await this.employeesRepository.PostEmployee(postEmployeesDTO);

                if (newItem == null)
                {
                    return NoContent();
                }

                var newEmployee = await this.employeesRepository.GetEmployees(newItem.EmployeeNumber);

                if (newEmployee == null)
                {
                    new Exception($"Something went wrong when trying to retrieve employee number = {newItem.EmployeeNumber}");
                }
                var unit = await this.workingUnitRepository.GetUnit(newItem.UnitId);
                var department = await this.departmentRepository.GetDepartment(unit.DepartmentId);
                var status = await this.statusRepository.GetEmployeeStatus(newItem.StatusId);

                var redirectToItemDTO = newEmployee.EmployeesDTOConversion(unit, department, status);

                return CreatedAtAction(nameof(Get), new { empNum = newItem.EmployeeNumber }, postEmployeesDTO);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{empNum}")]
        public async Task<ActionResult<EmployeesDTO>> Delete(string empNum)
        {
            try
            {
                var data = await this.employeesRepository.DeleteEmployee(empNum);
                if (data == null)
                {
                    return NotFound();
                }

                var employee = await this.employeesRepository.GetEmployees();
                var UnitData = await this.workingUnitRepository.GetUnit();
                var DepartmentData = await this.departmentRepository.GetDepartment();
                var StatusData = await this.statusRepository.GetEmployeeStatus();

                var empToDTO = employee.EmployeesDTOConversion(UnitData, DepartmentData, StatusData);
                return Ok(empToDTO);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
    }
}
