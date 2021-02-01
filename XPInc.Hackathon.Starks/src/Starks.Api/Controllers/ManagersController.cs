using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XPInc.Hackathon.Starks.Application.Queries.Manager;

namespace Starks.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManagersController : ControllerBase
    {
        private readonly IManagerQueries _managerQueries;

        public ManagersController(IManagerQueries managerQueries)
        {
            _managerQueries = managerQueries;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetManager(Guid id)
        {
            var manager = await _managerQueries.GetManagerByIdAsync(id);

            if (manager != null)
                return Ok(manager);
            else
                return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetManager([FromQuery]string email)
        {
            var manager = await _managerQueries.GetManagerByEmailAsync(email);

            if (manager != null)
                return Ok(manager);
            else
                return NoContent();
        }
    }
}
