using System;
using System.Collections.Generic;
using System.Text;
using XPInc.Hackathon.Starks.Domain.SeedWork;

namespace XPInc.Hackathon.Starks.Domain.AggregatesModel.AlertAggregate
{
    public interface IAlertRepository : IRepository<Alert>
    {
        Alert Add(Alert alert);
    }
}
