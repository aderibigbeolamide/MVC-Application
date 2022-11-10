using MVCVottingApp.Data.Base;
using MVCVottingApp.Model;

namespace MVCVottingApp.Interface.Repository
{
    public interface IPositionRepository : IEntityBaseRepository<Position>
    {
         Task<List<Position>> GetAllPositionAsync();
    }
}