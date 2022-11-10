using Microsoft.EntityFrameworkCore;
using MVCVottingApp.Data;
using MVCVottingApp.Data.Base;
using MVCVottingApp.Interface.Repository;
using MVCVottingApp.Model;

namespace MVCVottingApp.Implementation.Repository
{
    public class ElectionRepository : EntityBaseRepository<Election>, IElectionRepository
    {
        public ElectionRepository(MVCVottingAppContext context) : base(context)
        {
        }

        public async Task<List<Election>> GetAllElectionAsync()
        {
            return await _context.Elections.ToListAsync();
        }

        public async Task<Election> GetElectionByIdAsync(int id)
        {
            return await _context.Elections.FirstOrDefaultAsync(x => x.id == id);
        }
    }
}