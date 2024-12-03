using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Entities.Auth;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Countries.Queries
{
    public class GetAllPersonCommandHandler(DataContext context)
        : IRequestHandler<GetAllCountryPersonCommand, List<ApplicationUser>>
    {
        public async Task<List<ApplicationUser>> 
            Handle(GetAllCountryPersonCommand request, CancellationToken cancellationToken)
        {
            return await context.Countries
                .Include(x => x.User)
                .SelectMany(x=>x.User)
                .OrderBy(a => a.Country.Count)
                .ToListAsync(cancellationToken);
        }
    }
}
