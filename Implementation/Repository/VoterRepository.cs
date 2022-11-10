using Microsoft.EntityFrameworkCore;
using MVCVottingApp.Data;
using MVCVottingApp.Data.Base;
using MVCVottingApp.Interface.Repository;
using MVCVottingApp.Model;

namespace MVCVottingApp.Implementation.Repository
{
    public class VoterRepository : EntityBaseRepository<Voter>, IVoterRepository
    {
        public VoterRepository(MVCVottingAppContext context) : base(context)
        {
        }

        public async Task<List<Voter>> GetAllVoterAsync()
        {
            return await _context.Voters.ToListAsync();
        }

        public async Task<Voter> GetVoterByIdAsync(int id)
        {
            return await _context.Voters.FirstOrDefaultAsync(x => x.id == id);
        }
    }
}