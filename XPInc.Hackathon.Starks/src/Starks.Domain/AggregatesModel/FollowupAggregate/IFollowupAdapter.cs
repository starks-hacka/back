using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XPInc.Hackathon.Starks.Domain.AggregatesModel.FollowupAggregate
{
    public interface IFollowupAdapter
    {
        Task<string> MakeCall(short coutry, long phone);
    }
}
