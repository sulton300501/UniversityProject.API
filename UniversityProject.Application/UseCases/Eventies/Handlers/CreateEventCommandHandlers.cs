using MediatR;
using Microsoft.AspNetCore.Hosting;
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
    public class CreateEventCommandHandlers : IRequestHandler<CreateEventCommand, Event>
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _env;

        public CreateEventCommandHandlers(DataContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<Event> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var files = request.Picture;
            var path = Path.Combine(_env.WebRootPath, "EventImage");
            var fileName = "";

            fileName = Guid.NewGuid().ToString() + "EventImage" + files.FileName;
            var filePath = Path.Combine(path, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
               await files.CopyToAsync(stream);
            }



            var data = new Event()
            {
                Name = request.Name,            
                Created_at = DateTime.UtcNow,
                Deleted_at = null,
                PictureUrl = fileName,
                Description = request.Description,
                Date= DateTime.UtcNow

            };


            await _context.Events.AddAsync(data);
            await _context.SaveChangesAsync();




            return data;

        }
    }
}
