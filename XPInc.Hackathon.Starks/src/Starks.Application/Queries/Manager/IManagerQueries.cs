using System;
using System.Threading.Tasks;

namespace XPInc.Hackathon.Starks.Application.Queries.Manager
{
    public interface IManagerQueries
    {
        Task<Manager> GetManagerByIdAsync(Guid id);
        Task<Manager> GetManagerByEmailAsync(string email);
    }
}
