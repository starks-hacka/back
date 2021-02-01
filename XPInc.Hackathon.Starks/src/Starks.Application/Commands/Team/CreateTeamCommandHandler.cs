using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using XPInc.Hackathon.Starks.Domain.AggregatesModel.TeamAggregate;

namespace XPInc.Hackathon.Starks.Application.Commands.Team
{
    public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, bool>
    {
        private readonly ITeamRepository _teamRepository;

        public CreateTeamCommandHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<bool> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            _teamRepository.Add(new Domain.AggregatesModel.TeamAggregate.Team(
                request.Name,
                request.ManagerId,
                request.Alliance,
                request.Tribe,
                request.Email,
                Guid.NewGuid()));

            return await _teamRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);
        }
    }
}
