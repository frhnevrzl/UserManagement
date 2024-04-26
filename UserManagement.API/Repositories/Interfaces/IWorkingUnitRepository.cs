using UserManagement.API.Entity;

namespace UserManagement.API.Repositories.Interfaces
{
    public interface IWorkingUnitRepository
    {
        Task<IEnumerable<WorkingUnit>> GetUnit();
        Task<WorkingUnit> GetUnit(int id);
    }
}
