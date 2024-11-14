using MediatR;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Application.UseCases.Authorses.Commands;
using UniversityProject.Domain.Entities;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Authorses.Handlers
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommands, Author>
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _env;

        public CreateAuthorCommandHandler(DataContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<Author> Handle(CreateAuthorCommands request, CancellationToken cancellationToken)
        {


            var files = request.Picture;
            var path = Path.Combine(_env.WebRootPath, "AuthorImage");
            var fileName = "";

            fileName = Guid.NewGuid().ToString()+"AuthorImage"+files.FileName;
            var filePath = Path.Combine(path, fileName);
            using(var stream = new FileStream(filePath , FileMode.Create))
            {
                await files.CopyToAsync(stream);
            }



            var data = new Author()
            {
                Full_name = request.Full_name,
                Year = request.Year,
                Bio_wikipediya = request.Bio_wikipediya,
                Created_at = DateTime.UtcNow,
                Deleted_at = null,
                PictureUrl=fileName,
                country_id=request.country_id

            };


            await _context.Authors.AddAsync(data);
            await _context.SaveChangesAsync();




            return data;
            



        }
    }
}
