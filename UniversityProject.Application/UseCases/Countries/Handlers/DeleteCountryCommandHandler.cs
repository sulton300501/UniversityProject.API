using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Application.UseCases.Authorses.Commands;
using UniversityProject.Application.UseCases.Countries.Commands;
using UniversityProject.Domain.Entities;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Countries.Handlers
{
    public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, Country>
    {
        private readonly DataContext _context;

        public DeleteCountryCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Country> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            var data = await _context.Countries.FirstOrDefaultAsync(x => x.Id == request.CountryId);
            if (data == null)
            {
                throw new Exception("Not found");
            }

            _context.Countries.Remove(data);
            await _context.SaveChangesAsync();



            return data;
        }
    }
}
