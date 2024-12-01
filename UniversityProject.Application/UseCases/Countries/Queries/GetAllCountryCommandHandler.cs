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
    public class GetAllCountryCommandHandler(DataContext context)
        : IRequestHandler<GetAllCountryCommand, IEnumerable<Country>>
    {
        public async Task<IEnumerable<Country>> 
            Handle(GetAllCountryCommand request, CancellationToken cancellationToken)
        {
            return await context.Countries
                .Include(a => a.Books)
                .Include(a => a.User)
                .Include(a => a.Author)
                .OrderBy(x => x.Name)
                .ToListAsync(cancellationToken);
        }
    }
}
