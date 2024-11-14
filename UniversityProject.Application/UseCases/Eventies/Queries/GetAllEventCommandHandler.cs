using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Entities;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Eventies.Queries
{
    public class GetAllEventCommandHandler : IRequestHandler<GetAllEventsCommand, List<Event>>
    {

        private readonly DataContext _context;

        public GetAllEventCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Event>> Handle(GetAllEventsCommand request, CancellationToken cancellationToken)
        {
           var data = await _context.Events.ToListAsync(cancellationToken);
            return data;
        }
    }
}
