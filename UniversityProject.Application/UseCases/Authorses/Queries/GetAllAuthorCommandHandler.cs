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
    public class GetAllAuthorCommandHandler : IRequestHandler<GetAllAuthorCommand, List<Author>>
    {

        private readonly DataContext _context;

        public GetAllAuthorCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Author>> Handle(GetAllAuthorCommand request, CancellationToken cancellationToken)
        {


            var data = await _context.Authors.ToListAsync();
            return data;

        }
    }
}
