using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XPInc.Hackathon.Starks.Domain.AggregatesModel.AlertAggregate;
using XPInc.Hackathon.Starks.Domain.AggregatesModel.FollowupAggregate;
using XPInc.Hackathon.Starks.Domain.AggregatesModel.ManagerAggregate;
using XPInc.Hackathon.Starks.Domain.AggregatesModel.TeamAggregate;

namespace XPInc.Hackathon.Starks.Application.Commands.Alert
{
    public class ReceiveAlertCommandHandler : IRequestHandler<ReceiveAlertCommand, bool>
    {
        private readonly IAlertRepository _alertRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IManagerRepository _managerRepository;
        private readonly IFollowupAdapter _followupAdapter;

        public ReceiveAlertCommandHandler(
            IAlertRepository alertRepository,
            ITeamRepository teamRepository,
            IManagerRepository managerRepository,
            IFollowupAdapter followupAdapter)
        {
            _alertRepository = alertRepository;
            _teamRepository = teamRepository;
            _managerRepository = managerRepository;
            _followupAdapter = followupAdapter;
        }

        public async Task<bool> Handle(ReceiveAlertCommand request, CancellationToken cancellationToken)
        {
            _alertRepository.Add(new Domain.AggregatesModel.AlertAggregate.Alert(
                request.Alerta,
                request.Host,
                request.Prioridade,
                request.Ambiente,
                request.Corretora,
                request.Equipe,
                request.Email_app,
                request.Criticidade,
                request.Status,
                Guid.NewGuid()));

            var result = await _alertRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);

            if (result)
            {
                var team = await _teamRepository.GetByEmailAsync(request.Email_app);
                var phone = team.GetMemberToCall();

                if (phone == null)
                {
                    var manager = await _managerRepository.GetAsync(team.ManagerId);
                    phone = Convert.ToInt64(manager.Phone);
                }

                var code = await _followupAdapter.MakeCall(55, (long)phone);
                return !string.IsNullOrEmpty(code);
            }
            else
                return false;
        }
    }
}
