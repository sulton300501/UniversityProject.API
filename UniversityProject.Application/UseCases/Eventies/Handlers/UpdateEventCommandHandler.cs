using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Application.UseCases.Eventies.Commands;
using UniversityProject.Domain.Entities;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Eventies.Handlers
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, Event>
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _env;

        public UpdateEventCommandHandler(DataContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<Event> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var email = await _context.Events.FirstOrDefaultAsync(x => x.Id == request.EventId);



            var files = request.Picture;
            var path = Path.Combine(_env.WebRootPath, "EventImage");
            var fileName = "";

            if (files != null)
            {

                if (!string.IsNullOrEmpty(email.PictureUrl))
                {
                    var oldFilePath = Path.Combine(path, email.PictureUrl);
                    if (File.Exists(oldFilePath))
                    {
                        File.Delete(oldFilePath);
                    }
                }



                fileName = Guid.NewGuid().ToString() + Path.GetExtension(files.FileName);
                var filePath = Path.Combine(path, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await stream.CopyToAsync(stream);
                }






            }





            var data = new Event()
            {
                Name = request.Name,              
                Created_at = DateTime.UtcNow,
                Deleted_at = null,
                PictureUrl = fileName,
                Description=request.Description,
                Date=DateTime.UtcNow

            };


            _context.Events.Update(data);
            await _context.SaveChangesAsync(cancellationToken);

            return email;


        }
    }
}
