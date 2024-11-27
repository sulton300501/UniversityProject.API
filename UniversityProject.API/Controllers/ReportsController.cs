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
    public class ReportsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ReportsController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpPost]
        public async Task<IActionResult> createReport(CreateReportsCommand command, CancellationToken cancellation)
        {
            var result = await _mediator.Send(command, cancellation);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> updateReport(UpdateReportsCommand commad, CancellationToken cancellation)
        {
            var result = await _mediator.Send(commad, cancellation);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> deleteReport(DeleteReportsCommand command, CancellationToken cancellation)
        {
            var result = await _mediator.Send(command, cancellation);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> getALlReport(CancellationToken cancellation)
        {
            var data = new GetAllReportsCommand();;
            var result = await _mediator.Send(data, cancellation);
            return Ok(result);
        }





    }

}
