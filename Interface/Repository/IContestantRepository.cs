using MVCVottingApp.Data.Base;
using MVCVottingApp.Model;

namespace MVCVottingApp.Interface.Repository
{
    public interface IContestantRepository: IEntityBaseRepository<Contestant>
    {
        Task<List<Contestant>> GetAllContestantAsync();
        Task<Contestant> GetContestantByIdAsync(int id);
        Task<Contestant> GetContestantByGradeAsync(decimal grade);
    }
}