﻿using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Entities;

namespace UniversityProject.Application.UseCases.Books.Commands
{
    public class UpdateBookCommand : IRequest<Book>
    {
        public int BookId { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public int? CategoryId { get; set; }
        public int? AuthorId { get; set; }
        public int? CountryId { get; set; }
        public int? Year { get; set; }
        public string? Description { get; set; }
        public int? Length { get; set; }
        public IFormFile? Picture { get; set; }
        public int? Count { get; set; }
    }
}
