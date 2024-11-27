using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityProject.Domain.Entities.DTOs
{
    public class RegisterDTO
    {

        public string Full_name { get; set; } = "John Doe";
        public string PhoneNumer { get; set; } = "+998901234567";
        public string Email { get; set; } = "SecurePassword123";
        public string Password { get; set; } = "SecurePassword123";
        public int country_id { get; set; }
        public IFormFile? Picture { get; set; }
    }
}
