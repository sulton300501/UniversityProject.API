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
    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, Country>
    {
        private readonly DataContext _context;

        public CreateCountryCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Country> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {

            var data = new Country()
            {
                Name = request.CountryName,
                Count = request.Count,
                CreatedAt = DateTime.UtcNow,
                DeletedAt = null,


            };

            await _context.Countries.AddAsync(data);
            await _context.SaveChangesAsync();

            return data;



        }
    }
}
