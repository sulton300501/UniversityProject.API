using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
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
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Author>
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _env;

        public UpdateAuthorCommandHandler(DataContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<Author> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {

            var email = await _context.Authors.FirstOrDefaultAsync(x => x.Id == request.AuthorId);



            var files = request.Picture;
            var path = Path.Combine(_env.WebRootPath, "AuthorImage");
            var fileName = "";

            if (files != null)
            {

                if (!string.IsNullOrEmpty(email.PictureUrl))
                {
                    var oldFilePath = Path.Combine(path , email.PictureUrl);
                    if(File.Exists(oldFilePath))
                    {
                        File.Delete(oldFilePath);
                    }
                }



                fileName = Guid.NewGuid().ToString() + Path.GetExtension(files.FileName);
                var filePath = Path.Combine(path, fileName);
                using(var stream =new FileStream(filePath , FileMode.Create))
                {
                    await stream.CopyToAsync(stream);
                }


                



            }





            var data = new Author()
            {
                Full_name = request.Full_name,
                Year = request.Year,
                Bio_wikipediya = request.Bio_wikipediya,
                Created_at = DateTime.UtcNow,
                Deleted_at = null,
                PictureUrl = fileName,
                country_id = request.country_id

            };


             _context.Authors.Update(data);
            await _context.SaveChangesAsync(cancellationToken);

            return email;





        }
    }
}
