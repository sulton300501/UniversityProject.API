using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Entities;

namespace UniversityProject.Application.UseCases.Books.Commands
{
    public class CreateBookCommand : IRequest<Book>
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Category_id { get; set; }
        public int Author_id { get; set; }
        public int Country_id { get; set; }
        public int Year {  get; set; }
        public string Description { get; set; }
        public int Length { get; set; }
        public IFormFile Picture { get; set; }
        public int Count { get; set; }
    }
}
