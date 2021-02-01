using System;
using System.Collections.Generic;

namespace XPInc.Hackathon.Starks.Application.Queries.Team
{
    public class Team
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Manager Manager { get; set; }
        public IEnumerable<TeamMember> TeamMembers { get; set; }
        public string Alliance { get; set; }
        public string Tribe { get; set; }
    }

    public class Manager
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }

    }

    public class TeamMember
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public DateTime Date { get; set; }
    }
}
