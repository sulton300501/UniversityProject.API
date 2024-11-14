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
    public class UpdateAuthorCommand : IRequest<Author>
    {
        public int AuthorId { get; set; }
        public string Full_name { get; set; }
        public string? Year { get; set; }
        public string Bio_wikipediya { get; set; }



        public IFormFile? Picture { get; set; }
        public int country_id { get; set; }
    }
}
