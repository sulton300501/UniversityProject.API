using MediatR;
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
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand, Event>
    {
        private readonly DataContext _context;

        public DeleteEventCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Event> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var data = await _context.Events.FirstOrDefaultAsync(x => x.Id == request.EventId);
            if (data == null)
            {
                throw new Exception("Not found");
            }

            _context.Events.Remove(data);
            await _context.SaveChangesAsync();

            return data;
        }
    }
}
