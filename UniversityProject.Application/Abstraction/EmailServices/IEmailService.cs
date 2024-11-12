using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Entities.DTOs;

namespace UniversityProject.Application.Abstraction.EmailServices
{
    public interface IEmailService
    {
        void SendEmail(EmailDTO emailDTO);
    }
}
