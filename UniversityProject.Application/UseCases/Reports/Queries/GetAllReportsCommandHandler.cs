using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Entities;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Reports.Queries
{
    public class GetAllReportsCommandHandler : IRequestHandler<GetAllReportsCommand, List<Report>>
    {
        private readonly DataContext _context;

        public GetAllReportsCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Report>> Handle(GetAllReportsCommand request, CancellationToken cancellationToken)
        {
            var data = await _context.Reports.ToListAsync();
            return data;
        }
    }
}
