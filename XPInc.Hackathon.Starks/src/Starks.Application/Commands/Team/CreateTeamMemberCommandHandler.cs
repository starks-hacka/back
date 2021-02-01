using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using XPInc.Hackathon.Starks.Domain.AggregatesModel.TeamAggregate;

namespace XPInc.Hackathon.Starks.Application.Commands.Team
{
    public class CreateTeamMemberCommandHandler : IRequestHandler<CreateTeamMemberCommand, bool>
    {
        private readonly ITeamRepository _teamRepository;

        public CreateTeamMemberCommandHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<bool> Handle(CreateTeamMemberCommand request, CancellationToken cancellationToken)
        {
            _teamRepository.Add(new TeamMember(
                request.Email,
                request.Name,
                request.Surname,
                request.Phone,
                request.Date,
                request.TeamId,
                Guid.NewGuid()));

            return await _teamRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);
        }
    }
}
