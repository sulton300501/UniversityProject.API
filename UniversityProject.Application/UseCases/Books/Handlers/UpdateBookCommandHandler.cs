using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Application.UseCases.Books.Commands;
using UniversityProject.Domain.Entities;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Books.Handlers
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Book>
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _env;

        public UpdateBookCommandHandler(DataContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<Book> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {

            var data = await _context.Books.FirstOrDefaultAsync(x => x.Id == request.BookId);

            if (data == null)
            {
                throw new Exception("nit found");
            }


            var files = request.Picture;
            var path = Path.Combine(_env.WebRootPath, "BookImage");
            var fileName = "";


            if(files != null)
            {
                if(!string.IsNullOrEmpty(data.PictureUrl))
                {
                    var oldPicture = Path.Combine(path, data.PictureUrl);
                    if(File.Exists(oldPicture))
                    {
                        File.Delete(oldPicture);
                    }
                }


                fileName = Guid.NewGuid().ToString() + "BookImage" + files.FileName;
                var filePath = Path.Combine(path, fileName);
                using(var stream = new FileStream(filePath , FileMode.Create))
                {
                    await files.CopyToAsync(stream);
                }

            }

            var book = new Book()
            {
                Name = request.Name,
                Type = request.Type,
                category_id = request.Category_id,
                author_id = request.Author_id,
                countr_id = request.Country_id,
                Year = request.Year,
                Description = request.Description,
                Length = request.Length,
                Created_at = DateTime.UtcNow,
                Deleted_at = null,
                PictureUrl = fileName,
                Count = request.Count,
            };



             _context.Books.Update(data);
            await _context.SaveChangesAsync();
            return data;









        }
    }
}
