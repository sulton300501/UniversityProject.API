using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UniversityProject.Application.UseCases.Users.Commands;
using UniversityProject.Application.UseCases.Users.Queries;

namespace UniversityProject.API.Controllers;

[ApiController]
[Route("api")]
[ApiExplorerSettings(GroupName = "Main")]

public class UserController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// Creates a new user.
    /// Ushbu endpoint yangi foydalanuvchi qo'shish uchun ishlatiladi.
    /// Foydalanuvchi foydalanuvchi ismi, biografiyasi va boshqa kerakli ma'lumotlarni yuborishi kerak.
    /// </summary>
    /// <param name="command">Foydalanuvchi yaratish uchun ma'lumotlar</param>
    /// <param name="cancellation">So'rovni bekor qilish uchun token</param>
    /// <returns>
    /// Muvaffaqiyatli bo'lsa, yangi foydalanuvchi ma'lumotlarini qaytaradi.
    /// Aks holda, xatolik xabarini qaytaradi.
    /// </returns>
    [HttpPost("user")]
    [SwaggerOperation(
        Summary = "Foydalanuvchi qo'shish",
        Description = "Yangi foydalanuvchi ma'lumotlarini JSON ko'rinishida yuboring."
    )]
    [ProducesResponseType(typeof(string),StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateUser
        ([FromForm]CreateUserCommands command, CancellationToken cancellation)
    {
        return Ok(await mediator.Send(command, cancellation));
    }
    
    /// <summary>
    /// Updates an existing user.
    /// Ushbu endpoint mavjud foydalanuvchi ma'lumotlarini yangilash uchun ishlatiladi.
    /// Foydalanuvchi foydalanuvchi ID'si va yangilangan ma'lumotlarni yuborishi kerak.
    /// </summary>
    /// <param name="command">Foydalanuvchini yangilash uchun ma'lumotlar</param>
    /// <param name="cancellation">So'rovni bekor qilish uchun token</param>
    /// <returns>
    /// Muvaffaqiyatli bo'lsa, yangilangan ma'lumotlarni qaytaradi.
    /// Aks holda, xatolik xabarini qaytaradi.
    /// </returns>
    [HttpPut("user")]
    [SwaggerOperation(
        Summary = "Foydalanuvchi yangilash",
        Description = "Yangilangan foydalanuvchi ma'lumotlarini JSON ko'rinishida yuboring."
    )]
    [ProducesResponseType(typeof(string),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateUser([FromForm]UpdateUserCommand command, CancellationToken cancellation)
    {
        return Ok(await mediator.Send(command, cancellation));
    }
    
    /// <summary>
    /// Deletes an existing user.
    /// Ushbu endpoint mavjud foydalanuvchini o'chirish uchun ishlatiladi.
    /// Foydalanuvchi foydalanuvchi ID'sini yuborishi kerak.
    /// </summary>
    /// <param name="command">Foydalanuvchini o'chirish uchun ma'lumotlar</param>
    /// <param name="cancellation">So'rovni bekor qilish uchun token</param>
    /// <returns>
    /// Muvaffaqiyatli bo'lsa, foydalanuvchini o'chirish natijasini qaytaradi.
    /// Aks holda, xatolik xabarini qaytaradi.
    /// </returns>
    [HttpDelete("user/{id}")]
    [SwaggerOperation(
        Summary = "Foydalanuvchi o'chirish",
        Description = "Foydalanuvchini o'chirish uchun foydalanuvchi ID'sini yuboring."
    )]
    [ProducesResponseType(typeof(string),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteUser(DeleteUserCommand command, CancellationToken cancellation)
    {
        return Ok(await mediator.Send(command, cancellation));
    }
    
    /// <summary>
    /// Gets all users.
    /// Ushbu endpoint foydalanuvchilarni ko'rish uchun ishlatiladi.
    /// </summary>
    /// <param name="cancellation">So'rovni bekor qilish uchun token</param>
    /// <returns>
    /// Muvaffaqiyatli bo'lsa, foydalanuvchilarni ko'rish natijasini qaytaradi.
    /// Aks holda, xatolik xabarini qaytaradi.
    /// </returns>
    [HttpGet("users")]
    [SwaggerOperation(
        Summary = "Foydalanuvchilarni ko'rish",
        Description = "Foydalanuvchilarni ko'rish uchun foydalanuvchi ID'sini yuboring."
    )]
    [ProducesResponseType(typeof(string),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetUsers(CancellationToken cancellation)
    {
        return Ok(await mediator.Send(new GetAllUserCommand(), cancellation));
    }
    
    /// <summary>
    /// Gets a user by ID.
    /// Ushbu endpoint foydalanuvchini ID orqali olish uchun ishlatiladi.
    /// Foydalanuvchi foydalanuvchi ID'sini yuborishi kerak.
    /// </summary>
    /// <param name="id">Foydalanuvchini olish uchun ma'lumot</param>
    /// <param name="cancellation">So'rovni bekor qilish uchun token</param>
    /// <returns>
    /// Muvaffaqiyatli bo'lsa, foydalanuvchini ko'rish natijasini qaytaradi.
    /// Aks holda, xatolik xabarini qaytaradi.
    /// </returns>
    [HttpGet("user/{id}")]
    [SwaggerOperation(
        Summary = "Foydalanuvchini ko'rish",
        Description = "Foydalanuvchini ko'rish uchun foydalanuvchi ID'sini yuboring."
    )]
    [ProducesResponseType(typeof(string),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetUserById(int id, CancellationToken cancellation)
    {
        var data = new GetUserByIdCommand
        {
            Id = id
        };
        
        return Ok(await mediator.Send(data, cancellation));
    }
}