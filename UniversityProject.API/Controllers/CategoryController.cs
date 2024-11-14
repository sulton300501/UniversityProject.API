using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityProject.Application.UseCases.Authorses.Commands;
using UniversityProject.Application.UseCases.Authorses.Queries;
using UniversityProject.Application.UseCases.Categories.Commands;
using UniversityProject.Application.UseCases.Categories.Queries;

namespace UniversityProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpPost]
        public async Task<IActionResult> createAuthor(CreateCategoryCommand command, CancellationToken cancellation)
        {
            var result = await _mediator.Send(command, cancellation);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> updateAuthor(UpdateCategoryCommand commad, CancellationToken cancellation)
        {
            var result = await _mediator.Send(commad, cancellation);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> deleteAuthor(DeleteCategoryCommand command, CancellationToken cancellation)
        {
            var result = await _mediator.Send(command, cancellation);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> getALlAuthor(CancellationToken cancellation)
        {
            var data = new GetAllCategoryCommand();
            var result = await _mediator.Send(data, cancellation);
            return Ok(result);
        }





    }
}
