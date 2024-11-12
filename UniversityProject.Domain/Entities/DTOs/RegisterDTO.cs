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

        public string Full_name { get; set; }
        public string PhoneNumer { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int country_id { get; set; }
        public IFormFile? Picture { get; set; }
    }
}
