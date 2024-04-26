using System.Net.Http.Json;
using UserManagement.DTO.ModelsDTO;
using UserManagement.Web.Services.Interfaces;

namespace UserManagement.Web.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        public readonly HttpClient _httpClient;
        public DepartmentServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<DepartmentDTO>>GetListDepartment()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/Department");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<DepartmentDTO>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<DepartmentDTO>>();
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
    }
}
