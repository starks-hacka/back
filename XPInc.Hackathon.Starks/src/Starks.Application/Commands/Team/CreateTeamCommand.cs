using MediatR;
using System;
using System.Runtime.Serialization;

namespace XPInc.Hackathon.Starks.Application.Commands.Team
{
    [DataContract]
    public class CreateTeamCommand : IRequest<bool>
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Guid ManagerId { get; set; }

        [DataMember]
        public string Alliance { get; set; }

        [DataMember]
        public string Tribe { get; set; }

        [DataMember]
        public string Email { get; set; }
    }
}
