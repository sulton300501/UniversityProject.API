    using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UniversityProject.Application.UseCases.Authorses.Commands;
using UniversityProject.Application.UseCases.Authorses.Queries;

namespace UniversityProject.API.Controllers
{
    [Route("api")]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "Main")] // Swagger guruhi nomi
    [SwaggerTag("Mualliflar uchun API")]
    [ApiController]
    public class AuthorController(IMediator mediator)
        : ControllerBase
    {
        /// <summary>
        /// Creates a new author.
        /// Ushbu endpoint yangi muallif qo'shish uchun ishlatiladi.
        /// Foydalanuvchi muallif ismi, biografiyasi va boshqa kerakli ma'lumotlarni yuborishi kerak.
        /// </summary>
        /// <param name="command">Muallif yaratish uchun ma'lumotlar</param>
        /// <param name="cancellation">So'rovni bekor qilish uchun token</param>
        /// <returns>
        /// Muvaffaqiyatli bo'lsa, yangi muallif ma'lumotlarini qaytaradi.
        /// Aks holda, xatolik xabarini qaytaradi.
        /// </returns>
        [HttpPost("author")]
        [SwaggerOperation(
            Summary = "Muallif qo'shish",
            Description = "Yangi muallif ma'lumotlarini JSON ko'rinishida yuboring."
        )]
        [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAuthor([FromForm]CreateAuthorCommands command, CancellationToken cancellation)
        {
            var result = await mediator.Send(command, cancellation);
            return Ok(result);
        }

        /// <summary>
        /// Updates an existing author.
        /// Ushbu endpoint mavjud muallif ma'lumotlarini yangilash uchun ishlatiladi.
        /// Foydalanuvchi muallifning ID'si va yangilangan ma'lumotlarni yuborishi kerak.
        /// </summary>
        /// <param name="command">Muallifni yangilash uchun ma'lumotlar</param>
        /// <param name="cancellation">So'rovni bekor qilish uchun token</param>
        /// <returns>
        /// Muvaffaqiyatli bo'lsa, yangilangan ma'lumotlarni qaytaradi.
        /// Aks holda, xatolik xabarini qaytaradi.
        /// </returns>
        [HttpPut("author/{id}")]
        [SwaggerOperation(
            Summary = "Muallifni yangilash",
            Description = "Yangi muallif ma'lumotlarini JSON ko'rinishida yuboring."
        )]
        [ProducesResponseType(typeof(string),StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorCommand command, CancellationToken cancellation)
        {
            var result = await mediator.Send(command, cancellation);
            return Ok(result);
        }

        /// <summary>
        /// Deletes an author.
        /// Ushbu endpoint muallifni o'chirish uchun ishlatiladi.
        /// Foydalanuvchi muallifning ID'sini yuborishi kerak.
        /// </summary>
        /// <param name="id">Muallifni o'chirish uchun ma'lumot</param>
        /// <param name="cancellation">So'rovni bekor qilish uchun token</param>
        /// <returns>
        /// Muvaffaqiyatli bo'lsa, muvaffaqiyatli o'chirildi xabarini qaytaradi.
        /// Aks holda, xatolik xabarini qaytaradi.
        /// </returns>
        [HttpDelete("author/{id}")]
        [SwaggerOperation(
            Summary = "Muallifni o'chirish",
            Description = "Ushbu endpoint orqali ID orqali ma'lumotlar bazasidan muallifni o'chirishingiz mumkin."
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAuthor(int id, CancellationToken cancellation)
        {
            var data = new DeleteAuthorCommand
            {
                Id = id
            };
            
            var result = await mediator.Send(data, cancellation);
            return Ok(result);
        }

        /// <summary>
        /// Retrieves all authors.
        /// Ushbu endpoint barcha mualliflarni olish uchun ishlatiladi.
        /// </summary>
        /// <param name="cancellation">So'rovni bekor qilish uchun token</param>
        /// <returns>
        /// Mualliflar ro'yxatini qaytaradi.
        /// Agar mualliflar topilmasa, bo'sh ro'yxat qaytaradi.
        /// </returns>
        [HttpGet("authors")]
        [SwaggerOperation(
            Summary = "Mualliflar ro'yxatini olish",
            Description = "Ushbu endpoint orqali barcha mualliflarning ma'lumotlarini olishingiz mumkin."
        )]
        public async Task<IActionResult> GetALlAuthor(CancellationToken cancellation)
        {
            var data = new GetAllAuthorCommand();
            var result = await mediator.Send(data, cancellation);
            return Ok(result);
        }
        
        /// <summary>
        /// Retrieves an author by ID.
        /// Ushbu endpoint muallifni ID orqali olish uchun ishlatiladi.
        /// Foydalanuvchi muallifning ID'sini yuborishi kerak.
        /// </summary>
        /// <param name="id">Muallifni olish uchun ma'lumot</param>
        /// <param name="cancellation">So'rovni bekor qilish uchun token</param>
        /// <returns>
        /// Muvaffaqiyatli bo'lsa, muallif ma'lumotlarini qaytaradi.
        /// Aks holda, xatolik xabarini qaytaradi.
        /// </returns>
        [HttpGet("author/{id}")]
        [SwaggerOperation(
            Summary = "Muallifni olish",
            Description = "Ushbu endpoint orqali ID orqali ma'lumotlar bazasidan muallifni olishingiz mumkin."
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAuthorById(int id, CancellationToken cancellation)
        {
            var data = new GetAuthorByIdCommand
            {
                Id = id
            };
            
            var result = await mediator.Send(data, cancellation);
            return Ok(result);
        }
    }
}
