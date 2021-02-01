using System;
using System.Collections.Generic;
using System.Text;
using XPInc.Hackathon.Starks.Domain.AggregatesModel.AlertAggregate;

namespace XPInc.Hackathon.Starks.Infrastructure.Repositories
{
    public class AlertRepository : RepositoryBase, IAlertRepository
    {
        #region Constructors
        public AlertRepository(StarksContext context) : base(context)
        {
        }
        #endregion

        public Alert Add(Alert alert)
        {
            return _context.Alerts.Add(alert).Entity;
        }
    }
}
