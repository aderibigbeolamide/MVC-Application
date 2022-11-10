using MVCVottingApp.Data.Base;
using MVCVottingApp.Model;

namespace MVCVottingApp.Interface.Repository
{
    public interface IVoterRepository : IEntityBaseRepository<Voter>
    {
         Task<List<Voter>> GetAllVoterAsync();
    }
}