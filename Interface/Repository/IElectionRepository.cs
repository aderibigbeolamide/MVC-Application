using MVCVottingApp.Data.Base;
using MVCVottingApp.Model;

namespace MVCVottingApp.Interface.Repository
{
    public interface IElectionRepository : IEntityBaseRepository<Election>
    {
        Task<List<Election>> GetAllElectionAsync();
        Task<Election> GetElectionByIdAsync(int id);
    }
}