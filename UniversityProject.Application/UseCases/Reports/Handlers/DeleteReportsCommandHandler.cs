using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class DeleteReportsCommandHandler : IRequestHandler<DeleteReportsCommand, Report>
    {

        private readonly DataContext _context;

        public DeleteReportsCommandHandler(DataContext context)
        {
            _context = context;
        }

        public  async Task<Report> Handle(DeleteReportsCommand request, CancellationToken cancellationToken)
        {
            var data = await _context.Reports.FirstOrDefaultAsync(x => x.Id == request.ReportsId);
            if (data == null)
            {
                throw new Exception("Not found");
            }

            _context.Reports.Remove(data);
            await _context.SaveChangesAsync();



            return data;
        }
    }
}
