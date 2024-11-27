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
    public class EventController : ControllerBase
    {

        private readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }




        [HttpPost]
        public async Task<IActionResult> createEvent(CreateEventCommand command, CancellationToken cancellation)
        {
            var result = await _mediator.Send(command, cancellation);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> updateEvent(UpdateEventCommand commad, CancellationToken cancellation)
        {
            var result = await _mediator.Send(commad, cancellation);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> deleteEvent(DeleteEventCommand command, CancellationToken cancellation)
        {
            var result = await _mediator.Send(command, cancellation);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> getALlEvent(CancellationToken cancellation)
        {
            var data = new GetAllEventsCommand();
            var result = await _mediator.Send(data, cancellation);
            return Ok(result);
        }

    }
}
