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
                Deleted_at= null,
              
                PictureUrl=fileName,
                Role = "User",


            };

            await _context.Users.AddAsync(appUser);
            await _context.SaveChangesAsync();

            return Ok("Succesfully");



          


        }



        [HttpPost("SignIn")]
        public async Task<IActionResult> Login(LoginDTO login)
        {

            var email = await _context.Users.FirstOrDefaultAsync(x=>x.Email==login.Email);
            if (email == null )
            {
                return Ok("not registered");
            }else if (email.Password != login.Password)
            {
                return Ok("Passsword is not correct");
            }

           
           

            var appUser = new ApplicationUser()
            {
                Full_name = email.Full_name,
                PhoneNumber = email.PhoneNumber,
               
                Email = login.Email,
                PictureUrl = email.PictureUrl,
                Deleted_at = null,
                Created_at = email.Created_at,
                Role = email.Role
            };

            var token = await _authService.GenerateToken(appUser);
            return Ok(new { Token = token });




        }


        [HttpPost]
        public async Task<IActionResult> ChangeEmail(ChangeEmailDTO emailDTO)
        {
            var email = await _context.Users.FirstOrDefaultAsync(x => x.Email == emailDTO.CurrentEmail);

            if(email == null)
            {
                return Ok("email not found");
            }

            if(email.Email == emailDTO.NewEmail)
            {
                return Ok("The same email");
            }

            email.Email= emailDTO.NewEmail;
             _context.Users.Update(email);
            await _context.SaveChangesAsync();
            return Ok("succes");




        }


        
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangerPasswordDTO changePasswordDto)
        {
        
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == changePasswordDto.Email);
            if (user == null)
            {
                return Ok("User not found.");
            }

          
            if (user.Password != changePasswordDto.CurrentPassword)
            {
                return Ok("Current password is incorrect.");
            }

          
            if (changePasswordDto.CurrentPassword == changePasswordDto.NewPassword)
            {
                return Ok("New password cannot be the same as the current password.");
            }

         
            user.Password = changePasswordDto.NewPassword;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return Ok("Password updated successfully.");
        }









    }
}
