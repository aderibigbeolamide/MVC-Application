using MVCVottingApp.Data.Base;
using MVCVottingApp.Model;

namespace MVCVottingApp.Interface.Repository
{
    public interface IVoteRepository : IEntityBaseRepository<Vote>
    {
         Task<List<Vote>> GetAllVoteAsync();
    }
}