using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Entities;

namespace UniversityProject.Application.UseCases.Authorses.Commands
{
    public class CreateAuthorCommands : IRequest<Author>
    {
        public string? FullName { get; set; }
        public string? Year { get; set; }
        public string BioWikipediya { get; set; }
        
        public IFormFile? Picture { get; set; }
        public int CountryId { get; set; }
    }
}
