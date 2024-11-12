using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityProject.Domain.Entities.Auth
{
    public class ApplicationUser 
    {

        public int Id {  get; set; }
        public string Full_name { get; set; }    
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime Created_at {  get; set; }
        public DateTime? Deleted_at {  get; set; }
      
        
        public string? PictureUrl { get; set; }
        public string Role { get; set; }




    }
}
