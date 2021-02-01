using System;

namespace XPInc.Hackathon.Starks.Domain.AggregatesModel.TeamAggregate
{
    public class TeamMember : Employee
    {
        #region Properties
        public Guid TeamId { get; private set; }
        public DateTime Date { get; private set; }
        //public Team Team { get; private set; }
        //public IDictionary<short, Guid> Failovers { get; private set; }
        #endregion

        #region Constructors
        public TeamMember(string email, string name, string surname, string phone, DateTime date, Guid teamId, /*IDictionary<short, Guid> failovers = null,*/ Guid id)
            : base(email, name, surname, phone, id)
        {
            Date = date;
            TeamId = teamId;
            //Team = team;
            //Failovers = failovers;
        }
        #endregion

        //public void AddFailover(Guid teamMemberId)
        //{
        //    if (Failovers == null)
        //        Failovers = new Dictionary<short, Guid>();
            
        //    if (Failovers.Where(f => f.Value.Equals(teamMemberId)).Any())
        //    {
        //        throw new DomainException("Team member already included");
        //    }
        //    else
        //    {
        //        Failovers.Add((short)(Failovers.Count + 1), teamMemberId);
        //    }
        //}

        //public void AddFailovers(IDictionary<short, Guid> failovers)
        //{
        //    Failovers = failovers;
        //}
    }
}
