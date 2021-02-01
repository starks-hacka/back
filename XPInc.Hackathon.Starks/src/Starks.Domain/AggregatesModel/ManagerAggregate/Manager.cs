using System;
using XPInc.Hackathon.Starks.Domain.SeedWork;

namespace XPInc.Hackathon.Starks.Domain.AggregatesModel.ManagerAggregate
{
    public class Manager : Employee, IAggregateRoot
    {
        public Manager(string email, string name, string surname, string phone, Guid id) 
            : base(email, name, surname, phone, id)
        {
        }
    }
}
