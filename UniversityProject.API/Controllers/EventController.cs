using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityProject.Application.UseCases.Authorses.Commands;
using UniversityProject.Application.UseCases.Authorses.Queries;
using UniversityProject.Application.UseCases.Eventies.Commands;
using UniversityProject.Application.UseCases.Eventies.Queries;

namespace UniversityProject.API.Controllers
{
    [ApiExplorerSettings(GroupName = "Main")]
    [Route("api/[controller]")]
    [ApiController]
    public class EventController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        
        [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> createEvent(CreateEventCommand command, CancellationToken cancellation)
        {
            var result = await mediator.Send(command, cancellation);
            return Ok(result);
        }

        [HttpPut]
        
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> updateEvent(UpdateEventCommand commad, CancellationToken cancellation)
        {
            var result = await mediator.Send(commad, cancellation);
            return Ok(result);
        }

        [HttpDelete]
        
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> deleteEvent(DeleteEventCommand command, CancellationToken cancellation)
        {
            var result = await mediator.Send(command, cancellation);
            return Ok(result);
        }

        [HttpGet]
        
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> getALlEvent(CancellationToken cancellation)
        {
            var data = new GetAllEventsCommand();
            var result = await mediator.Send(data, cancellation);
            return Ok(result);
        }

    }
}
