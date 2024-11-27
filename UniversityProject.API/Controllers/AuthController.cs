using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using UniversityProject.Application.Abstraction.AuthServices;
using UniversityProject.Domain.Entities.Auth;
using UniversityProject.Domain.Entities.DTOs;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.API.Controllers
{
    [ApiExplorerSettings(GroupName = "Authentication")]
    [Route("api/[controller]/[action]")]
    [ApiController]
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
        /// </summary>
        /// <param name="register">Registration details.</param>
        /// <returns>Success or error message.</returns>
        [HttpPost("SignUp")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register(RegisterDTO register)
        {
            // Check if the email already exists
            var existingUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == register.Email);
            if (existingUser != null)
            {
                return Conflict("This email is already registered.");
            }

            // Handle file upload
            string fileName = null;
            if (register.Picture != null && register.Picture.Length > 0)
            {
                var validExtensions = new[] { ".jpg", ".png", ".jpeg" };
                var fileExtension = Path.GetExtension(register.Picture.FileName).ToLower();

                if (!validExtensions.Contains(fileExtension))
                {
                    return BadRequest("Invalid file format. Only JPG, PNG, and JPEG are allowed.");
                }

                var path = Path.Combine(_env.WebRootPath, "UserImage");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                fileName = $"{Guid.NewGuid()}-{Path.GetFileName(register.Picture.FileName)}";
                var filePath = Path.Combine(path, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await register.Picture.CopyToAsync(stream);
                }
            }

            // Hash the password
            var passwordHasher = new PasswordHasher<ApplicationUser>();
            var appUser = new ApplicationUser
            {
                Full_name = register.Full_name,
                Email = register.Email,
                PhoneNumber = register.PhoneNumer,
                Created_at = DateTime.UtcNow,
                country_id = register.country_id,
                PictureUrl = fileName,
                Role = "User",
                Password = passwordHasher.HashPassword(null, register.Password)
            };

            // Save the user to the database
            await _context.Users.AddAsync(appUser);
            await _context.SaveChangesAsync();

            return Created("", "User registered successfully.");
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == login.Email);
            if (user == null)
            {
                return NotFound("Email is not registered.");
            }

            var passwordHasher = new PasswordHasher<ApplicationUser>();
            var passwordVerificationResult = passwordHasher.VerifyHashedPassword(user, user.Password, login.Password);
            if (passwordVerificationResult != PasswordVerificationResult.Success)
            {
                return Unauthorized("Password is incorrect.");
            }

            var token = await _authService.GenerateToken(user);
            return Ok(new { Token = token });
        }

        [HttpPost("ChangeEmail")]
        public async Task<IActionResult> ChangeEmail(ChangeEmailDTO emailDTO)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == emailDTO.CurrentEmail);
            if (user == null)
            {
                return NotFound("Current email not found.");
            }

            if (user.Email == emailDTO.NewEmail)
            {
                return BadRequest("New email cannot be the same as the current email.");
            }

            user.Email = emailDTO.NewEmail;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return Ok("Email updated successfully.");
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangerPasswordDTO changePasswordDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == changePasswordDto.Email);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var passwordHasher = new PasswordHasher<ApplicationUser>();
            var passwordVerificationResult = passwordHasher.VerifyHashedPassword(user, user.Password, changePasswordDto.CurrentPassword);
            if (passwordVerificationResult != PasswordVerificationResult.Success)
            {
                return Unauthorized("Current password is incorrect.");
            }

            if (changePasswordDto.CurrentPassword == changePasswordDto.NewPassword)
            {
                return BadRequest("New password cannot be the same as the current password.");
            }

            user.Password = passwordHasher.HashPassword(user, changePasswordDto.NewPassword);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return Ok("Password updated successfully.");
        }
    }
}
