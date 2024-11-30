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
        public string FullName { get; set; }    
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt {  get; set; }
        public DateTime? DeletedAt {  get; set; }
        public string? PictureUrl { get; set; }
        public string Role { get; set; }
        public int CountryId { get; set; }
        
        public ICollection<Report> Report { get; set; }
        public Country Country { get; set; }
    }
}
