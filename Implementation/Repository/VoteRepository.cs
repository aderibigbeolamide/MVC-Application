using Microsoft.EntityFrameworkCore;
using MVCVottingApp.Data;
using MVCVottingApp.Data.Base;
using MVCVottingApp.Interface.Repository;
using MVCVottingApp.Model;

namespace MVCVottingApp.Implementation.Repository
{
    public class VoteRepository : EntityBaseRepository<Vote>, IVoteRepository
    {
        public VoteRepository(MVCVottingAppContext context) : base(context)
        {
        }

        public async Task<List<Vote>> GetAllVoteAsync()
        {
            return await _context.Votes.ToListAsync();
        }

        public async Task<Vote> GetVoteByIdAsync(int id)
        {
            return await _context.Votes.FirstOrDefaultAsync(x => x.id == id);
        }
    }
}