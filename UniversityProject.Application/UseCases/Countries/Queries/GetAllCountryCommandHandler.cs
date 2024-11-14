using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Entities;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Countries.Queries
{
    public class GetAllCountryCommandHandler : IRequestHandler<GetAllCountryCommand, IEnumerable<Country>>
    {

        private readonly DataContext _context;

        public GetAllCountryCommandHandler(DataContext context)
        {
            _context = context;

        }
        public async Task<IEnumerable<Country>> Handle(GetAllCountryCommand request, CancellationToken cancellationToken)
        {
            
            var data = await _context.Countries.ToListAsync(cancellationToken);
            return data;
        }
    }
}
