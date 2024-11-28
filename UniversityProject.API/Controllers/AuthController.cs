using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using UniversityProject.Application.Abstraction.AuthServices;
using UniversityProject.Domain.Entities.Auth;
using UniversityProject.Domain.Entities.DTOs;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.API.Controllers
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "Authentication")] // API hujjatlash guruhi
    [Route("api")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _env;

        public AuthController(IAuthService authService, DataContext context, IWebHostEnvironment env)
        {
            _authService = authService;
            _context = context;
            _env = env;
        }

        /// <summary>
        /// Registers a new user.
        /// Ushbu endpoint yangi foydalanuvchini ro'yxatdan o'tkazish uchun ishlatiladi. 
        /// Foydalanuvchi ismi, email, telefon raqami, parol va rasm yuborishi kerak.
        /// </summary>
        /// <param name="register">Ro'yxatdan o'tish uchun foydalanuvchi ma'lumotlari</param>
        /// <returns>
        /// Agar muvaffaqiyatli bo'lsa, foydalanuvchini ro'yxatdan o'tkazadi. 
        /// Konflikt bo'lsa, email oldin ro'yxatdan o'tganligini bildiradi.
        /// </returns>
        [HttpPost("register")]
        [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Register([FromForm] RegisterDTO register)
        {
            if (await _context.Users.AnyAsync(x => x.Email == register.Email))
                return Conflict("This email is already registered.");

            string fileName = null;
            if (register.Picture != null)
            {
                fileName = await SaveFile(register.Picture);
                if (fileName == null)
                    return BadRequest("Invalid file format. Only JPG, PNG, and JPEG are allowed.");
            }

            var passwordHasher = new PasswordHasher<ApplicationUser>();
            var appUser = new ApplicationUser
            {
                Full_name = register.FullName,
                Email = register.Email,
                PhoneNumber = register.PhoneNumer,
                Created_at = DateTime.UtcNow,
                country_id = (int)register.CountryId,
                PictureUrl = fileName,
                Role = "User",
                Password = passwordHasher.HashPassword(null, register.Password)
            };

            await _context.Users.AddAsync(appUser);
            await _context.SaveChangesAsync();

            return Created("", "User registered successfully.");
        }

        /// <summary>
        /// Logs in a user and generates a JWT token.
        /// Ushbu endpoint foydalanuvchini tizimga kirish uchun ishlatiladi. 
        /// Foydalanuvchi email va parolni yuborishi kerak.
        /// </summary>
        /// <param name="login">Kirish uchun foydalanuvchi ma'lumotlari</param>
        /// <returns>
        /// Agar muvaffaqiyatli bo'lsa, JWT token qaytaradi. 
        /// Aks holda, noto'g'ri email yoki parolni bildiradi.
        /// </returns>
        [HttpPost("login")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == login.Email);
            if (user == null)
                return NotFound("Email is not registered.");

            var passwordHasher = new PasswordHasher<ApplicationUser>();
            if (passwordHasher.VerifyHashedPassword(user, user.Password, login.Password) !=
                PasswordVerificationResult.Success)
                return Unauthorized("Password is incorrect.");

            var token = await _authService.GenerateToken(user);
            return token != null ? Ok(token) : BadRequest("Token generation failed.");
        }

        /// <summary>
        /// Changes the user's email.
        /// Foydalanuvchi mavjud emailni yangi emailga o'zgartirish uchun ishlatiladi.
        /// </summary>
        /// <param name="emailDTO">Emailni o'zgartirish uchun ma'lumotlar</param>
        /// <returns>
        /// Muvaffaqiyatli bo'lsa, email o'zgartiriladi. 
        /// Aks holda, foydalanuvchi topilmagani yoki yangi email bir xil ekanligi bildiriladi.
        /// </returns>
        [HttpPost("change-email")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ChangeEmail(ChangeEmailDTO emailDTO)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == emailDTO.CurrentEmail);
            if (user == null)
                return NotFound("Current email not found.");

            if (user.Email == emailDTO.NewEmail)
                return BadRequest("New email cannot be the same as the current email.");

            user.Email = emailDTO.NewEmail;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return Ok("Email updated successfully.");
        }

        /// <summary>
        /// Changes the user's password.
        /// Foydalanuvchi mavjud parolni yangi parolga o'zgartirish uchun ishlatiladi.
        /// </summary>
        /// <param name="changePasswordDto">Parolni o'zgartirish uchun ma'lumotlar</param>
        /// <returns>
        /// Muvaffaqiyatli bo'lsa, parol o'zgartiriladi. 
        /// Aks holda, noto'g'ri parol yoki yangi parol eski parolga teng ekanligi bildiriladi.
        /// </returns>
        [HttpPost("change-password")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ChangePassword(ChangerPasswordDTO changePasswordDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == changePasswordDto.Email);
            if (user == null)
                return NotFound("User not found.");

            var passwordHasher = new PasswordHasher<ApplicationUser>();
            if (passwordHasher.VerifyHashedPassword(user, user.Password, changePasswordDto.CurrentPassword) !=
                PasswordVerificationResult.Success)
                return Unauthorized("Current password is incorrect.");

            if (changePasswordDto.CurrentPassword == changePasswordDto.NewPassword)
                return BadRequest("New password cannot be the same as the current password.");

            user.Password = passwordHasher.HashPassword(user, changePasswordDto.NewPassword);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return Ok("Password updated successfully.");
        }

        /// <summary>
        /// Helper method to save a file on the server.
        /// Foydalanuvchi tomonidan yuborilgan faylni serverga saqlaydi.
        /// </summary>
        /// <param name="file">Foydalanuvchi yuklagan fayl</param>
        /// <returns>
        /// Muvaffaqiyatli bo'lsa, fayl nomini qaytaradi.
        /// Aks holda, null qaytaradi.
        /// </returns>
        private async Task<string> SaveFile(IFormFile file)
        {
            var validExtensions = new[] { ".jpg", ".png", ".jpeg" };
            var fileExtension = Path.GetExtension(file.FileName).ToLower();

            if (!validExtensions.Contains(fileExtension))
                return null;

            var path = Path.Combine(_env.WebRootPath, "UserImage");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var fileName = $"{Guid.NewGuid()}-{Path.GetFileName(file.FileName)}";
            var filePath = Path.Combine(path, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }
    }
}
