using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Entities;

namespace UniversityProject.Application.UseCases.Eventies.Commands
{
    public class CreateEventCommand : IRequest<Event>
    {
        public string Name { get; set; }
        public IFormFile Picture { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

    }
}
