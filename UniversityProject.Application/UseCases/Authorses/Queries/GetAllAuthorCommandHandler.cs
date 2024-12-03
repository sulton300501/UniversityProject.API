using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Entities;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Authorses.Queries
{
    public class GetAllAuthorCommandHandler(DataContext context)
        : IRequestHandler<GetAllAuthorCommand, List<Author>>
    {
        public async Task<List<Author>> Handle(GetAllAuthorCommand request, CancellationToken cancellationToken)
        {
            var data = await context.Authors
                // .Include(a => a.Books)
                // .Include(a => a.Country)
                .ToListAsync(cancellationToken);
            return data;
        }
    }
}
