using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XPInc.Hackathon.Starks.Domain.AggregatesModel.FollowupAggregate;

namespace XPInc.Hackathon.Starks.Application.Commands.Followup
{
    public class MakeCallTeamMemberCommandHandle : IRequestHandler<MakeCallTeamMemberCommand, bool>
    {
        private readonly IFollowupAdapter _followupAdapter;

        public MakeCallTeamMemberCommandHandle(IFollowupAdapter followupAdapter)
        {
            _followupAdapter = followupAdapter;
        }

        public async Task<bool> Handle(MakeCallTeamMemberCommand request, CancellationToken cancellationToken)
        {
            await _followupAdapter.MakeCall(55, request.Phone);

            return true;
        }
    }
}
