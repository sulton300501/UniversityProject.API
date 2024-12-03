using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UniversityProject.Application.UseCases.Books.Commands;
using UniversityProject.Application.UseCases.Books.Queries;

namespace UniversityProject.API.Controllers
{
    [Route("api")]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "Main")]
    [SwaggerTag("Kitoblar bilan ishlash uchun API")]
    [ApiController]
    public class BookController(IMediator mediator) : ControllerBase
    {
        [HttpPost("book")]
        [SwaggerOperation
            (Summary = "Kitob qo'shish",
            Description = "Yangi kitob ma'lumotlarini form data ko'rinishida yuboring.")
        ]
        [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateBook([FromForm]CreateBookCommand command, CancellationToken cancellation)
        {
            var result = await mediator.Send(command, cancellation);
            
            return Ok(result);
        }

        [HttpPut("book")]
        [SwaggerOperation
            (Summary = "Kitobni yangilash", 
            Description = "Kitobni yangilash uchun form data ko'rinishida yuboring.")
        ]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateBook([FromForm]UpdateBookCommand commad, CancellationToken cancellation)
        {
            var result = await mediator.Send(commad, cancellation);
            
            return Ok(result);
        }

        /// <summary>
        /// Kitobni o'chirish
        /// </summary>
        /// <param name="id">Kitob ID</param>
        /// <param name="cancellation"></param>
        [HttpDelete("book{id}")]
        [SwaggerOperation
            (Summary = "Kitobni o'chirish",
            Description = "Kitobni o'chirish uchun id param sifatida jo'nating.")
        ]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteBook(int id, CancellationToken cancellation)
        {
            var result = await mediator.Send(id, cancellation);
            
            return Ok(result);
        }

        [HttpGet("books")]
        [SwaggerOperation
            (Summary = "Kitobni olish",
            Description = "Barcha kitoblarni olish uchun hech nima talab qilinmaydi.")
        ]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetALlBook(CancellationToken cancellation)
        {
            var data = new GetAllBooksCommand();
            var result = await mediator.Send(data, cancellation);
            
            return Ok(result);
        }
    }
}
