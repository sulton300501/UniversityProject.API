using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityProject.Domain.Entities.DTOs
{
    public class RegisterDTO
    {
        /// <summary>
        /// Foydalanuvchining to'liq ismi
        /// </summary>
        [Required(ErrorMessage = "Full_name maydoni talab qilinadi.")]
        public string FullName { get; set; }

        /// <summary>
        /// Telefon raqami
        /// </summary>
        [Required(ErrorMessage = "PhoneNumer maydoni talab qilinadi.")]
        [Phone(ErrorMessage = "Telefon raqami noto'g'ri.")]
        public string PhoneNumer { get; set; }

        /// <summary>
        /// Elektron pochta
        /// </summary>
        [Required(ErrorMessage = "Email maydoni talab qilinadi.")]
        [EmailAddress(ErrorMessage = "Elektron pochta formati noto'g'ri.")]
        public string Email { get; set; }

        /// <summary>
        /// Parol
        /// </summary>
        [Required(ErrorMessage = "Password maydoni talab qilinadi.")]
        [MinLength(6, ErrorMessage = "Parol kamida 6 belgidan iborat bo'lishi kerak.")]
        public string Password { get; set; }

        /// <summary>
        /// Mamlakat identifikatori
        /// </summary>
        [Required(ErrorMessage = "Country_id maydoni talab qilinadi.")]
        public int? CountryId { get; set; }

        /// <summary>
        /// Rasm
        /// </summary>
        public IFormFile? Picture { get; set; }
    }
}
