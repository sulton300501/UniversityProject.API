using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversityProject.Application.UseCases.Countries.Commands;
using UniversityProject.Application.UseCases.Countries.Queries;

namespace UniversityProject.API.Controllers
{
    [ApiExplorerSettings(GroupName = "Main")]
    [Route("api/countries")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public CountryController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        /// <summary>
        /// Yangi mamlakat qo'shadi.
        /// </summary>
        /// <param name="command">Yaratish uchun kerak bo'lgan ma'lumotlar</param>
        /// <param name="cancellation">Bekor qilish tokeni</param>
        /// <returns>Yangi mamlakat haqida ma'lumot</returns>
        [HttpPost]
        [ProducesResponseType(typeof(string),StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCountry([FromBody] CreateCountryCommand command, CancellationToken cancellation)
        {
            var result = await _mediatr.Send(command, cancellation);
            return CreatedAtAction(nameof(GetAllCountries), new { id = result.Id }, result);
        }

        /// <summary>
        /// Mamlakatni o'chiradi.
        /// </summary>
        /// <param name="id">O'chiriladigan mamlakatning IDsi</param>
        /// <param name="cancellation">Bekor qilish tokeni</param>
        /// <returns>No content</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(string),StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string),StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCountry(int id, CancellationToken cancellation)
        {
            var command = new DeleteCountryCommand { CountryId = id };
            var result = await _mediatr.Send(command, cancellation);
            return NoContent();
        }

        /// <summary>
        /// Mamlakatni yangilaydi.
        /// </summary>
        /// <param name="id">Yangilanadigan mamlakatning IDsi</param>
        /// <param name="command">Yangilash uchun kerak bo'lgan ma'lumotlar</param>
        /// <param name="cancellation">Bekor qilish tokeni</param>
        /// <returns>Yangilangan mamlakat haqida ma'lumot</returns>
        [HttpPut]
        [ProducesResponseType(typeof(string),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string),StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCountry([FromBody] UpdateCountryCommand command, CancellationToken cancellation)
        {
            command.CountryId = command.CountryId; // Ensure the ID from the route is used
            var result = await _mediatr.Send(command, cancellation);
            return Ok(result);
        }

        /// <summary>
        /// Barcha mamlakatlarni qaytaradi.
        /// </summary>
        /// <param name="cancellation">Bekor qilish tokeni</param>
        /// <returns>Barcha mamlakatlar ro'yxati</returns>
        [HttpGet]
        [ProducesResponseType(typeof(string),StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCountries(CancellationToken cancellation)
        {
            var query = new GetAllCountryCommand();
            var result = await _mediatr.Send(query, cancellation);
            return Ok(result);
        }

        /// <summary>
        /// Barcha shaxs-mamlakat munosabatlarini qaytaradi.
        /// </summary>
        /// <param name="cancellation">Bekor qilish tokeni</param>
        /// <returns>Barcha shaxs-mamlakat munosabatlari</returns>
        [HttpGet("persons")]
        [ProducesResponseType(typeof(string),StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPersonCountries(CancellationToken cancellation)
        {
            var query = new GetAllCountryPersonCommand();
            var result = await _mediatr.Send(query, cancellation);
            return Ok(result);
        }
    }
}
