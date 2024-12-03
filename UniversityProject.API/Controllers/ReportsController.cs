using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityProject.Application.UseCases.Authorses.Commands;
using UniversityProject.Application.UseCases.Authorses.Queries;
using UniversityProject.Application.UseCases.Reports.Commands;
using UniversityProject.Application.UseCases.Reports.Queries;

namespace UniversityProject.API.Controllers
{
    [ApiExplorerSettings(GroupName = "Main")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        
        [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> createReport(CreateReportsCommand command, CancellationToken cancellation)
        {
            var result = await mediator.Send(command, cancellation);
            return Ok(result);
        }

        [HttpPut]
        
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> updateReport(UpdateReportsCommand commad, CancellationToken cancellation)
        {
            var result = await mediator.Send(commad, cancellation);
            return Ok(result);
        }

        [HttpDelete]
        
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> deleteReport(DeleteReportsCommand command, CancellationToken cancellation)
        {
            var result = await mediator.Send(command, cancellation);
            return Ok(result);
        }

        [HttpGet]
        
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> getALlReport(CancellationToken cancellation)
        {
            var data = new GetAllReportsCommand();;
            var result = await mediator.Send(data, cancellation);
            return Ok(result);
        }





    }

}
