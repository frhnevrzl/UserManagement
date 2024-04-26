using System.Net.Http.Json;
using UserManagement.DTO.ModelsDTO;
using UserManagement.Web.Services.Interfaces;

namespace UserManagement.Web.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly HttpClient _httpClient;
        public EmployeeServices(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<IEnumerable<EmployeesDTO>> GetEmployees()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/Employees");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<EmployeesDTO>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<EmployeesDTO>>();
                }
                else
                {
                    var msg = await response.Content.ReadAsStringAsync();
                    throw new Exception(msg);
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<EmployeesDTO> GetEmployee(string empNum)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Employees/{empNum}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(EmployeesDTO);
                    }
                    return await response.Content.ReadFromJsonAsync<EmployeesDTO>();
                }
                else
                {
                    var msg = await response.Content.ReadAsStringAsync();
                    throw new Exception(msg);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<EmployeesDTO> PostEmployee(PostEmployeesDTO postEmployeesDTO)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<PostEmployeesDTO>("api/Employees", postEmployeesDTO);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(EmployeesDTO);
                    }
                    return await response.Content.ReadFromJsonAsync<EmployeesDTO>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status: {message} Message - {message}");
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        
        public async Task<EmployeesDTO> DeleteEmployee(string empNum)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/Employees{empNum}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<EmployeesDTO>();
                }
                return default(EmployeesDTO);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
