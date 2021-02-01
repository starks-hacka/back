using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XPInc.Hackathon.Starks.Domain.SeedWork;

namespace XPInc.Hackathon.Starks.Domain.AggregatesModel.TeamAggregate
{
    public interface ITeamRepository : IRepository<Team>
    {
        Task<IEnumerable<Team>> GetAsync();
        Task<Team> GetAsync(Guid id);
        Task<Team> GetByEmailAsync(string email);
        Team Add(Team team);
        TeamMember Add(TeamMember teamMember);
    }
}
