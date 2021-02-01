using MediatR;
using System;

namespace XPInc.Hackathon.Starks.Application.Commands.Team
{
    public class CreateTeamMemberCommand : IRequest<bool>
    {
        public Guid TeamId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public DateTime Date { get; set; }
    }
}
