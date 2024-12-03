using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UniversityProject.Application.UseCases.Countries.Commands;
using UniversityProject.Application.UseCases.Countries.Queries;
using UniversityProject.Domain.Entities;

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
        [SwaggerOperation
            (Summary = "Yangi mamlakat qo'shish", 
            Description = "Yangi mamlakat ma'lumotlarini JSON ko'rinishida yuboring.")
        ]
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
        [SwaggerOperation
            (Summary = "Mamlakatni o'chirish",
            Description = "Mamlakatni o'chirish uchun IDni yuboring.")
        ]
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
        [SwaggerOperation
            (Summary = "Mamlakatni yangilash",
            Description = "Yangilash uchun mamlakat ma'lumotlarini JSON ko'rinishida yuboring.")
        ]
        [ProducesResponseType(typeof(string),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string),StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCountry([FromBody] UpdateCountryCommand? command, CancellationToken cancellation)
        {
            if (command is null)
                return BadRequest("Ma'lumot kiritilmadi");
            
            var countries = await _mediatr
                .Send(new GetAllCountryCommand(), cancellation);
            
            var enumerable = countries as Country[] ?? countries.ToArray();
            
            if (enumerable.All(x => x.Id != command.CountryId))
                return NotFound("Mamlakat topilmadi");
            
            var country = enumerable.FirstOrDefault(
                x => x.Id == command.CountryId);
            
            command.CountryId = command.CountryId; // Ensure the ID from the route is used
            command.Count = (int)(command.Count + country.Count);
            
            command.CountryName = string.IsNullOrEmpty
                (command.CountryName) ? country.Name : command.CountryName;
            
            var result = await _mediatr.Send(command, cancellation);
            return Ok(result);
        }

        /// <summary>
        /// Barcha mamlakatlarni qaytaradi.
        /// </summary>
        /// <param name="cancellation">Bekor qilish tokeni</param>
        /// <returns>Barcha mamlakatlar ro'yxati</returns>
        [HttpGet]
        [SwaggerOperation
            (Summary = "Barcha mamlakatlarni olish",
            Description = "Barcha mamlakatlarni olish uchun JSON ko'rinishida yuboring.")
        ]
        [ProducesResponseType(typeof(string),StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCountries(CancellationToken cancellation) 
            => Ok(await _mediatr.Send(new GetAllCountryCommand(), cancellation));
        
        /// <summary>
        /// Barcha shaxs-mamlakat munosabatlarini qaytaradi.
        /// </summary>
        /// <param name="cancellation">Bekor qilish tokeni</param>
        /// <returns>Barcha shaxs-mamlakat munosabatlari</returns>
        [HttpGet("persons")]
        [SwaggerOperation
            (Summary = "Viloyatlar bo'yicha foydalanuvchilarni olish.",
            Description = "Viloyatlar bo'yicha foydalanuvchilarni olish uchun viloyat id'sini yuboring.")
        ]
        [ProducesResponseType(typeof(string),StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPersonCountries(CancellationToken cancellation) 
            => Ok(await _mediatr.Send(new GetAllCountryPersonCommand(), cancellation));
    }
}
