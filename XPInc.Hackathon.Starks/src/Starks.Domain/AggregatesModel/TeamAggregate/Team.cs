using System;
using System.Collections.Generic;
using System.Linq;
using XPInc.Hackathon.Starks.Domain.SeedWork;

namespace XPInc.Hackathon.Starks.Domain.AggregatesModel.TeamAggregate
{
    public class Team : Entity, IAggregateRoot
    {
        #region Properties
        public string Name { get; private set; }
        public Guid ManagerId { get; private set; }
        public string Alliance { get; private set; }
        public string Tribe { get; private set; }
        public string Email { get; private set; }

        private readonly List<TeamMember> _teamMembers;
        public IReadOnlyCollection<TeamMember> TeamMembers => _teamMembers;

        //private readonly List<DutyShift> _dutyShifts;
        //public IReadOnlyCollection<DutyShift> DutyShifts => _dutyShifts;
        #endregion

        #region Constructors

        public Team(string name, Guid managerId, string alliance, string tribe, string email, Guid id)
            : base(id)
        {
            _teamMembers = new List<TeamMember>();

            Name = name ?? throw new ArgumentNullException(nameof(name));
            ManagerId = managerId;
            Alliance = alliance ?? throw new ArgumentNullException(nameof(alliance));
            Tribe = tribe ?? throw new ArgumentNullException(nameof(tribe));
            Email = email;
        }
        #endregion

        //public void AddTeamMember(string email, string MemberName, string memberSurname, string phone, Guid managerId)
        //{
        //    var existingOrderForProduct = _teamMembers.Where(o => o.Email == email).SingleOrDefault();

        //    if (existingOrderForProduct == null)
        //        _teamMembers.Add(new TeamMember(email, MemberName, memberSurname, phone, managerId));
        //}

        //public void AddDutyShift(DutyShift dutyShift)
        //{
        //var existingOrderForProduct = _dutyShifts.Where(o => o.Email == email)
        //    .SingleOrDefault();

        //if (existingOrderForProduct == null)
        //    _teamMembers.Add(new TeamMember(email, MemberName, memberSurname, phone));
        //}

        public long? GetMemberToCall()
        {
            var actualMember = TeamMembers.Where(tm => tm.Date.Date == DateTime.Now.Date).FirstOrDefault();

            if (actualMember != null)
                return Convert.ToInt64(actualMember.Phone);

            return null;
        }
    }

    //public abstract class DutyShift
    //{
    //    public string Email { get; set; }
    //}

    //public class WeeklyShift : DutyShift
    //{
    //    IEnumerable<short> Week { get; set; }
    //}

    //public class DailyShift : DutyShift
    //{
    //    IEnumerable<DayOfWeek> DaysOfWeek { get; set; }
    //}
}
