using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using UniversityProject.Application.Abstraction.AuthServices;
using UniversityProject.Domain.Entities.Auth;
using UniversityProject.Domain.Entities.DTOs;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        
        private readonly IAuthService  _authService;
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _env;

        public AuthController(IAuthService authService, DataContext context, IWebHostEnvironment env)
        {
            _authService = authService;
            _context = context;
            _env = env;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> Register(RegisterDTO register)
        {

            var email = await _context.Users.FirstOrDefaultAsync(x=>x.Email==register.Email);
            if (email != null)
            {
                return Ok("Registrdan otilgan");
            }

            var files = register.Picture;
            var path = Path.Combine(_env.WebRootPath + "/UserImage");
            var fileName = "";


            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Debug.WriteLine("Create");
            }


            fileName = Guid.NewGuid().ToString() + "UserImage" + files.FileName;
            var filePath = Path.Combine(path, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await files.CopyToAsync(stream);
            }




            var appUser = new ApplicationUser()
            {
                Full_name = register.Full_name,
                Password= register.Password,
                Email = register.Email,
                PhoneNumber=register.PhoneNumer,
                Created_at= DateTime.UtcNow,
                Deleted_at= DateTime.UtcNow,
              
                PictureUrl=fileName,
                Role = "User",


            };

            await _context.Users.AddAsync(appUser);
            await _context.SaveChangesAsync();

            return Ok("Succesfully");



            /*var user = await _userManager.CreateAsync(appUser, register.Password);
            if (user.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync("User"))
                {
                    await _roleManager.CreateAsync(new IdentityRole("User"));
                }

                await _userManager.AddToRoleAsync(appUser, "User");
                return Ok("Success");


            }
            else
            {
                return BadRequest("now work");
            }*/



        }



       /* [HttpPost("SignIn")]
        public async Task<IActionResult> Login(LoginDTO login)
        {

            var email = await _userManager.FindByEmailAsync(login.Email);
            if (email == null)
            {
                return Ok("not registered");
            }

            var roles = await _userManager.GetRolesAsync(email);
            var role = roles.FirstOrDefault() ?? "User";

            var appUser = new ApplicationUser()
            {
                Full_name = email.Full_name,
                PhoneNumber=email.PhoneNumber,
                country_id=email.country_id,
                Email = login.Email,
                PictureUrl=email.PictureUrl,
                Is_deleted=email.Is_deleted,
                Created_at=email.Created_at,
                Role = role
            };

            var token = await _authService.GenerateToken(appUser);
            return Ok(new { Token = token });




        }

*/







    }
}
