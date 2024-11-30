using MediatR;
using UniversityProject.Application.UseCases.Reports.Commands;
using UniversityProject.Domain.Entities;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Reports.Handlers
{
    public class CreateReportCommandHandlers(DataContext context)
        : IRequestHandler<CreateReportsCommand, Report>
    {
        public async Task<Report> Handle(CreateReportsCommand request, CancellationToken cancellationToken)
        {
            var data = new Report()
            {
                PageName = request.PageName,
                Description = request.Description,
                CreatedAt = DateTime.UtcNow,
                DeletedAt = null,
                ApplicationUserId= request.ApplicationUserId
            };

            await context.Reports.AddAsync(data);
            await context.SaveChangesAsync();
            return data;
        }
    }
}
