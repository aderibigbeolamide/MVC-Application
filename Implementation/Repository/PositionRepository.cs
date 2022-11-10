using Microsoft.EntityFrameworkCore;
using MVCVottingApp.Data;
using MVCVottingApp.Data.Base;
using MVCVottingApp.Interface.Repository;
using MVCVottingApp.Model;

namespace MVCVottingApp.Implementation.Repository
{
    public class PositionRepository : EntityBaseRepository<Position>, IPositionRepository
    {
        public PositionRepository(MVCVottingAppContext context) : base(context)
        {
        }

        public async Task<List<Position>> GetAllPositionAsync()
        {
            return await _context.Positions.ToListAsync();
        }

        public async Task<Position> GetPositionByIdAsync(int id)
        {
            return await _context.Positions.FirstOrDefaultAsync(x => x.id == id);
        }
    }
}