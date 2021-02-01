using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XPInc.Hackathon.Starks.Domain.AggregatesModel.TeamAggregate;

namespace XPInc.Hackathon.Starks.Infrastructure.Repositories
{
    public class TeamRepository : RepositoryBase, ITeamRepository
    {
        #region Constructors
        public TeamRepository(StarksContext context) : base(context) { }
        #endregion

        public async Task<IEnumerable<Team>> GetAsync()
        {
            return await _context
                    .Teams
                    .ToListAsync();
        }

        public async Task<Team> GetAsync(Guid id)
        {
            var team = await _context
                                .Teams
                                .FirstOrDefaultAsync(t => t.Id == id);
            if (team != null)
            {
                await _context.Entry(team)
                    .Collection(i => i.TeamMembers).LoadAsync();
            }

            return team;
        }

        public Team Add(Team team)
        {
            return _context.Teams.Add(team).Entity;
        }

        public TeamMember Add(TeamMember teamMember)
        {
            return _context.TeamMembers.Add(teamMember).Entity;
        }

        public async Task<Team> GetByEmailAsync(string email)
        {
            var team = await _context
                                .Teams
                                .FirstOrDefaultAsync(t => t.Email == email);
            if (team != null)
            {
                await _context.Entry(team)
                    .Collection(i => i.TeamMembers).LoadAsync();
            }

            return team;
        }
    }
}
