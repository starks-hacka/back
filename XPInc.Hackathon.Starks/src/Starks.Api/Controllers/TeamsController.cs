using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using XPInc.Hackathon.Starks.Application.Commands.Team;
using XPInc.Hackathon.Starks.Application.Queries.Team;

namespace Starks.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ITeamQueries _teamQueries;

        public TeamsController(
            IMediator mediator,
            ITeamQueries teamQueries)
        {
            _mediator = mediator;
            _teamQueries = teamQueries;
        }

        [HttpGet]
        [Produces("application/json")]
        [SwaggerResponse(StatusCodes.Status200OK, "Sucesso", typeof(IEnumerable<Team>))]
        public async Task<IActionResult> GetTeams()
        {
            var teams = await _teamQueries.GetAllTeams();

            if (teams != null)
                return Ok(teams);
            else
                return NoContent();
        }

        [HttpGet]
        [Route("{id}")]
        [Produces("application/json")]
        [SwaggerResponse(StatusCodes.Status200OK, "Sucesso", typeof(Team))]
        public async Task<IActionResult> GetTeams(Guid id)
        {
            var teams = await _teamQueries.GetTeamByIdWithManager(id);

            if (teams != null)
                return Ok(teams);
            else
                return NoContent();
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
            [Required] CreateTeamCommand createTeamCommand)
        {
            var response = await _mediator.Send(createTeamCommand);

            if (response)
                return new OkResult();
            else
                return BadRequest();
        }

        [HttpPost]
        [Route("{id}/members")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerResponse(StatusCodes.Status200OK, "Sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Parâmetros inválidos", typeof(ValidationProblemDetails))]
        [SwaggerOperation(
            Description = "Create Team Member",
            OperationId = "teams-members-create")]
        public async Task<IActionResult> CreateTeamMemberAsync(
            Guid id,
            [Required] CreateTeamMemberCommand createTeamMemberCommand)
        {
            createTeamMemberCommand.TeamId = id;

            var response = await _mediator.Send(createTeamMemberCommand);

            if (response)
                return new OkResult();
            else
                return BadRequest();
        }
    }
}
