using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XPInc.Hackathon.Starks.Application.Queries.Team
{
    public interface ITeamQueries
    {
        Task<IEnumerable<Team>> GetAllTeams();
        Task<Team> GetTeamByIdWithManager(Guid id);
    }
}
