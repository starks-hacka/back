using System;
using XPInc.Hackathon.Starks.Domain.SeedWork;

namespace XPInc.Hackathon.Starks.Infrastructure.Repositories
{
    public abstract class RepositoryBase
    {
        protected readonly StarksContext _context;
        public IUnitOfWork UnitOfWork => _context;

        #region Constructors
        public RepositoryBase(StarksContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        #endregion
    }
}
