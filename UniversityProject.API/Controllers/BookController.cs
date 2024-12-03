using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversityProject.Application.UseCases.Books.Commands;
using UniversityProject.Application.UseCases.Books.Queries;

namespace UniversityProject.API.Controllers
{
    [ApiExplorerSettings(GroupName = "Main")]
    [Route("api")]
    [ApiController]
    public class BookController(IMediator mediator) : ControllerBase
    {
        [HttpPost("book")]
        public async Task<IActionResult> CreateBook([FromForm]CreateBookCommand command, CancellationToken cancellation)
        {
            var result = await mediator.Send(command, cancellation);
            return Ok(result);
        }

        [HttpPut("book")]
        public async Task<IActionResult> UpdateBook(UpdateBookCommand commad, CancellationToken cancellation)
        {
            var result = await mediator.Send(commad, cancellation);
            return Ok(result);
        }

        [HttpDelete("book")]
        public async Task<IActionResult> DeleteBook(DeleteBookCommand command, CancellationToken cancellation)
        {
            var result = await mediator.Send(command, cancellation);
            return Ok(result);
        }

        [HttpGet("books")]
        public async Task<IActionResult> GetALlBook(CancellationToken cancellation)
        {
            var data = new GetAllBooksCommand();
            var result = await mediator.Send(data, cancellation);
            return Ok(result);
        }
        
        [HttpGet("category-book")]
        public async Task<IActionResult> GetBookCategories(CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetBookCategoriesQuery(), cancellationToken);
            return Ok(result);
        }
    }
}
