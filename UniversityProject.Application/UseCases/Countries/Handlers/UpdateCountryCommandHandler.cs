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
    public class UpdateCountryCommandHandler(DataContext context) 
        : IRequestHandler<UpdateCountryCommand, Country>
    {
        public async Task<Country> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            var data = await context.Countries
                .FirstOrDefaultAsync(x => x.Id == request.CountryId, cancellationToken: cancellationToken);
            
            if (data == null) throw new Exception("not found");
            data.Count = request.Count;
            data.Name = request.CountryName;
            await context.SaveChangesAsync(cancellationToken);
            return data;
        }
    }
}
