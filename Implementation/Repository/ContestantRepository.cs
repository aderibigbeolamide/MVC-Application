using Microsoft.EntityFrameworkCore;
using MVCVottingApp.Data;
using MVCVottingApp.Data.Base;
using MVCVottingApp.Interface.Repository;
using MVCVottingApp.Model;

namespace MVCVottingApp.Implementation.Repository
{
    public class ContestantRepository : EntityBaseRepository<Contestant>, IContestantRepository
    {
        public ContestantRepository(MVCVottingAppContext context) : base(context)
        {
        }

        public async Task<List<Contestant>> GetAllContestantAsync()
        {
            return await _context.Contestants.ToListAsync(); 
        }

        public async Task<Contestant> GetContestantByGradeAsync(decimal grade)
        {
            return await _context.Contestants.FirstOrDefaultAsync(x => x.Student.Grade == grade);
        }

        public async Task<Contestant> GetContestantByIdAsync(int id)
        {
            return await _context.Contestants.FirstOrDefaultAsync(c => c.id == id);
        }
    }
}