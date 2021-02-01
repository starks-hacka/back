using System;
using System.Threading.Tasks;
using XPInc.Hackathon.Starks.Domain.SeedWork;

namespace XPInc.Hackathon.Starks.Domain.AggregatesModel.ManagerAggregate
{
    public interface IManagerRepository : IRepository<Manager>
    {
        Task<Manager> GetAsync(Guid managerId);
        Task<Manager> GetAsync(string email);
    }
}
