using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Application.UseCases.Countries.Commands;
using UniversityProject.Domain.Entities;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Countries.Handlers
{
    public class CreateCountryCommandHandler(DataContext context)
        : IRequestHandler<CreateCountryCommand, Country>
    {
        public async Task<Country> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var data = new Country()
            {
                Name = request.CountryName,
                CreatedAt = DateTime.UtcNow
            };

            await context.Countries.AddAsync(data, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return data;
        }
    }
}
