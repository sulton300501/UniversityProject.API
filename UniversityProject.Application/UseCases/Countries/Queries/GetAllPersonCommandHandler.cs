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
    public class GetAllPersonCommandHandler : IRequestHandler<GetAllCountryPersonCommand, List<ApplicationUser>>
    {
        private readonly DataContext _context;

        public GetAllPersonCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<List<ApplicationUser>> Handle(GetAllCountryPersonCommand request, CancellationToken cancellationToken)
        {

            var result = await _context.Countries.SelectMany(x => x.User).ToListAsync();
            return result;


        }
    }
}
