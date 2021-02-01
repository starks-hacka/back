using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XPInc.Hackathon.Starks.Domain.AggregatesModel.ManagerAggregate;
using XPInc.Hackathon.Starks.Domain.AggregatesModel.TeamAggregate;

namespace XPInc.Hackathon.Starks.Application.Queries.Team
{
    public class TeamQueries : ITeamQueries
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IManagerRepository _managerRepository;

        public TeamQueries(ITeamRepository teamRepository, IManagerRepository managerRepository)
        {
            _teamRepository = teamRepository;
            _managerRepository = managerRepository;
        }

        public async Task<IEnumerable<Team>> GetAllTeams()
        {
            var teams = await _teamRepository.GetAsync();

            return teams.Select(t =>
                new Team
                {
                    Id = t.Id,
                    Name = t.Name,
                    Alliance = t.Alliance,
                    Tribe = t.Tribe,
                    //Manager = new Manager t.ManagerId
                }).ToList();
        }

        public async Task<Team> GetTeamByIdWithManager(Guid id)
        {
            var team = await _teamRepository.GetAsync(id);
            if (team == null)
                return null;

            var manager = await _managerRepository.GetAsync(team.ManagerId);

            return new Team
            {
                Id = team.Id,
                Name = team.Name,
                Alliance = team.Alliance,
                Tribe = team.Tribe,
                Manager = new Manager
                {
                    Id = manager.Id,
                    Email = manager.Email,
                    Name = manager.Name,
                    Surname = manager.Surname,
                    Phone = manager.Phone
                },
                TeamMembers = team.TeamMembers.Select(tm =>
                    new TeamMember
                    {
                        Id = tm.Id,
                        Email = tm.Email,
                        Name = tm.Name,
                        Surname = tm.Surname,
                        Phone = tm.Phone,
                        Date = tm.Date
                    }).ToList()
            };
        }
    }
}
