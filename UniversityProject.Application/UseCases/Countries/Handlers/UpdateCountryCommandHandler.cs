using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, Country>
    {
        private readonly DataContext _context;

        public UpdateCountryCommandHandler(DataContext context)
        {
            _context = context;
        }
        public async Task<Country> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {


            var data = await _context.Countries.FirstOrDefaultAsync(x => x.Id == request.CountryId);
            if (data == null)
            {
                throw new Exception("not found");
            }

            data.Count = request.Count;
            data.Name = request.CountryName;

            await _context.Countries.AddAsync(data);
            await _context.SaveChangesAsync();
            return data;


        }
    }
}
