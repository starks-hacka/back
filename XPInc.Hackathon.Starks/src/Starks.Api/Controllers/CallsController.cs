using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Starks.Infrastructure.TwiiloAdapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XPInc.Hackathon.Starks.Domain.AggregatesModel.FollowupAggregate;

namespace Starks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallsController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> MakeCallAsync()
        {
            IFollowupAdapter twiiloCalls = new TwiiloCalls();

            await twiiloCalls.MakeCall(55, 11976255210);

            return Ok();
        }
    }
}
