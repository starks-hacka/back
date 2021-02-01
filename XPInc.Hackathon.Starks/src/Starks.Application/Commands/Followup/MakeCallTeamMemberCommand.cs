using MediatR;

namespace XPInc.Hackathon.Starks.Application.Commands.Followup
{
    public class MakeCallTeamMemberCommand : IRequest<bool>
    {
        public long Phone { get; set; }
    }
}
