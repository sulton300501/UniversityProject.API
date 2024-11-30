using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityProject.Application.UseCases.Reports.Commands;
using UniversityProject.Domain.Entities;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Reports.Handlers
{
    public class UpdateReportsCommandHandler(DataContext context)
        : IRequestHandler<UpdateReportsCommand, Report>
    {
        public async Task<Report> Handle(UpdateReportsCommand request, CancellationToken cancellationToken)
        {
            var data = await context.Reports
                .FirstOrDefaultAsync(x => x.Id == request.ReportsId, cancellationToken);
            
            if (data == null) throw new Exception("Not found!");
            data.PageName = request.PageName;
            data.Description = request.Description;
            data.CreatedAt = DateTime.UtcNow;
            data.ApplicationUserId= request.ApplicationUserId;

            await context.SaveChangesAsync();
            return data;
        }
    }
}
