using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using UserManagement.API.Data;
using UserManagement.API.Entity;
using UserManagement.API.Repositories.Interfaces;
using UserManagement.DTO.ModelsDTO;

namespace UserManagement.API.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        protected AppDbContext _context;

        public EmployeesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var data = await this._context.Employees.ToListAsync();
            return data;
        }

        public async Task<Employee> GetEmployees(string empNum)
        {
            var data = await this._context.Employees.SingleOrDefaultAsync(x => x.EmployeeNumber == empNum);
            return data;
        }

        private async Task<bool> CheckData(string empNum)
        {
            return await this._context.Employees.Where(x=>x.EmployeeNumber == empNum).AnyAsync();
        }
        public async Task<Employee> PostEmployee(PostEmployeesDTO postEmployeesDTO)
        {
            if (await CheckData(postEmployeesDTO.EmployeeNumber) == false)
            {
                var data = new Employee()
                {
                    Nama = postEmployeesDTO.Nama,
                    EmployeeNumber = postEmployeesDTO.EmployeeNumber,
                    Email = postEmployeesDTO.Email,
                    Password = postEmployeesDTO.Password,
                    PhoneNumber = postEmployeesDTO.PhoneNumber,
                    Address = postEmployeesDTO.Address,
                    City = postEmployeesDTO.City,
                    Country = postEmployeesDTO.Country,
                    UnitId = postEmployeesDTO.UnitId,
                    StatusId = postEmployeesDTO.StatusId
                };
                var result = await this._context.Employees.AddAsync(data);
                await this._context.SaveChangesAsync();
                return result.Entity;
            }

            return null;
        }

        public Task<Employee> UpdateEmployee(string empNum, PostEmployeesDTO postEmployeesDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> DeleteEmployee(string empNum)
        {
            var item = await this._context.Employees.FirstOrDefaultAsync(x=>x.EmployeeNumber == empNum);

            if (item != null)
            {
                this._context.Employees.Remove(item);
                await this._context.SaveChangesAsync();
            }
            return item;
        }

    }
}
