using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Application.UseCases.Reports.Commands;
using UniversityProject.Domain.Entities;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Reports.Handlers
{
    public class CreateReportCommandHandlers : IRequestHandler<CreateReportsCommand, Report>
    {
        private readonly DataContext _context;

        public CreateReportCommandHandlers(DataContext context)
        {
            _context = context;
        }

        public async Task<Report> Handle(CreateReportsCommand request, CancellationToken cancellationToken)
        {
            var data = new Report()
            {
                Page_name = request.Page_name,
                Description = request.Description,
                Created_at = DateTime.UtcNow,
                Deleted_at = null,
                user_id=request.user_id


            };

            await _context.Reports.AddAsync(data);
            await _context.SaveChangesAsync();

            return data;
        }
    }
}
