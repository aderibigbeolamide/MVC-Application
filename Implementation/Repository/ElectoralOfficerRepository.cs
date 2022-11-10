using Microsoft.EntityFrameworkCore;
using MVCVottingApp.Data;
using MVCVottingApp.Data.Base;
using MVCVottingApp.Interface.Repository;
using MVCVottingApp.Model;

namespace MVCVottingApp.Implementation.Repository
{
    public class ElectoralOfficerRepository : EntityBaseRepository<ElectoralOfficer>, IElectoralOfficerRepository
    {
        public ElectoralOfficerRepository(MVCVottingAppContext context) : base(context)
        {
        }
    }
}