using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using XPInc.Hackathon.Starks.Domain.AggregatesModel.ManagerAggregate;

namespace XPInc.Hackathon.Starks.Infrastructure.Repositories
{
    public class ManagerRepository : RepositoryBase, IManagerRepository
    {
        #region Constructors
        public ManagerRepository(StarksContext context) : base(context) { }
        #endregion

        public async Task<Manager> GetAsync(Guid managerId)
        {
            return await _context
                    .Managers
                    .FirstOrDefaultAsync(m => m.Id == managerId);
        }

        public async Task<Manager> GetAsync(string email)
        {
            return await _context
                    .Managers
                    .FirstOrDefaultAsync(m => m.Email == email);
        }
    }
}
