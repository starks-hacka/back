using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using XPInc.Hackathon.Starks.Application.Commands.Alert;

namespace Starks.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AlertsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AlertsController(
            IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerResponse(StatusCodes.Status200OK, "Sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Parâmetros inválidos", typeof(ValidationProblemDetails))]
        [SwaggerOperation(
           Description = "Create Team",
           OperationId = "teams-create")]
        public async Task<IActionResult> CreateAsync(
           [Required] ReceiveAlertCommand receiveAlertCommand)
        {
            var response = await _mediator.Send(receiveAlertCommand);

            if (response)
                return new OkResult();
            else
                return BadRequest();
        }
    }
}
