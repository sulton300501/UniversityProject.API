using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UniversityProject.Application.UseCases.Books.Commands;
using UniversityProject.Application.UseCases.Books.Queries;
using UniversityProject.Domain.Entities;

namespace UniversityProject.API.Controllers
{
    [Route("api/book")]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "Main")]
    [SwaggerTag("Kitoblar bilan ishlash uchun API")]
    [ApiController]
    public class BookController(IMediator mediator) : ControllerBase
    {
        /// <summary>
        /// Kitob qo'shish
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerOperation
            (Summary = "Kitob qo'shish",
            Description = "Yangi kitob ma'lumotlarini form data ko'rinishida yuboring.")
        ]
        [ProducesResponseType(typeof(Book), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateBook([FromForm]CreateBookCommand command, CancellationToken cancellation)
        {
            var result = await mediator.Send(command, cancellation);
            return Ok(result);
        }

        /// <summary>
        /// Kitobni yangilash
        /// </summary>
        /// <param name="commad"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpPut]
        [SwaggerOperation
            (Summary = "Kitobni yangilash", 
            Description = "Kitobni yangilash uchun form data ko'rinishida yuboring.")
        ]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateBook([FromForm]UpdateBookCommand commad, CancellationToken cancellation)
        {
            var result = await mediator.Send(commad, cancellation);
            return Ok(result);
        }

        /// <summary>
        /// Kitobni o'chirish
        /// </summary>
        /// <param name="bookId">Kitob ID</param>
        /// <param name="cancellation"></param>
        [HttpDelete("{bookId}")]
        [SwaggerOperation
            (Summary = "Kitobni o'chirish",
            Description = "Kitobni o'chirish uchun id param sifatida jo'nating.")
        ]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteBook([FromRoute]int bookId, CancellationToken cancellation)
        {
            var data = new DeleteBookCommand
            {
                BookId = bookId
            };
            
            var result = await mediator.Send(data, cancellation);
            return Ok(result);
        }

        /// <summary>
        /// Barcha kitoblarni olish
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpGet]
        [SwaggerOperation
            (Summary = "Kitobni olish",
            Description = "Barcha kitoblarni olish uchun hech nima talab qilinmaydi.")
        ]
        [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetALlBook(CancellationToken cancellation)
        {
            var data = new GetAllBooksCommand();
            var result = await mediator.Send(data, cancellation);
            return Ok(result);
        }
    }
}
