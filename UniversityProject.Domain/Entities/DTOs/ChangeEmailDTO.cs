using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityProject.Domain.Entities.DTOs
{
    public class ChangeEmailDTO
    {
        public string CurrentEmail { get; set; }
        public string NewEmail { get; set; }
    }
}
