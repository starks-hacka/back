using System;

namespace XPInc.Hackathon.Starks.Domain.SeedWork
{
    public abstract class Entity
    {
        public Guid Id { get; private set; }

        protected Entity(Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
        }
    }
}
