using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityProject.Application.UseCases.Authorses.Commands;
using UniversityProject.Application.UseCases.Authorses.Queries;

namespace UniversityProject.API.Controllers
{
    [ApiExplorerSettings(GroupName = "Main")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {


        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpPost]
        public async Task<IActionResult> createAuthor(CreateAuthorCommands command , CancellationToken cancellation)
        {
            var result = await _mediator.Send(command , cancellation);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> updateAuthor(UpdateAuthorCommand commad , CancellationToken cancellation)
        {
            var result = await _mediator.Send(commad, cancellation);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> deleteAuthor(DeleteAuthorCommand command , CancellationToken cancellation)
        {
            var result = await _mediator.Send(command, cancellation);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> getALlAuthor(CancellationToken cancellation)
        {
            var data = new GetAllAuthorCommand();
            var result = await _mediator.Send(data, cancellation);
            return Ok(result);
        }


    }
}
