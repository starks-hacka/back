using System;
using XPInc.Hackathon.Starks.Domain.SeedWork;

namespace XPInc.Hackathon.Starks.Domain.AggregatesModel
{
    public abstract class Employee : Entity
    {
        #region Properties
        public string Email { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Phone { get; private set; }
        #endregion

        #region Constructors
        protected Employee(string email, string name, string surname, string phone, Guid? id = null) : base(id)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Surname = surname ?? throw new ArgumentNullException(nameof(surname));
            Phone = phone ?? throw new ArgumentNullException(nameof(phone));
        }
        #endregion
    }
}
