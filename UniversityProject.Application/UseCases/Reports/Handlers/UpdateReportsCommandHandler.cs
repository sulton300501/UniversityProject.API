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
    public class UpdateReportsCommandHandler : IRequestHandler<UpdateReportsCommand, Report>
    {
        private readonly DataContext _context;

        public UpdateReportsCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Report> Handle(UpdateReportsCommand request, CancellationToken cancellationToken)
        {
            var data = await _context.Reports.FirstOrDefaultAsync(x => x.Id == request.ReportsId);
            if (data == null)
            {
                throw new Exception("not found");
            }

            data.Page_name = request.Page_name;
            data.Description = request.Description;
            data.Created_at = DateTime.UtcNow;
            data.Deleted_at = null;
            data.user_id= request.user_id;

            await _context.Reports.AddAsync(data);
            await _context.SaveChangesAsync();
            return data;

        }
    }
}
