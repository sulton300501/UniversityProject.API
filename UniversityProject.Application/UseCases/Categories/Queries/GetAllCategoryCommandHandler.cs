using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityProject.Domain.Entities;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Categories.Queries
{
    public class GetAllCategoryCommandHandler : IRequestHandler<GetAllCategoryCommand, List<Category>>
    {
        private readonly DataContext _context;

        public GetAllCategoryCommandHandler(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Category>> Handle(GetAllCategoryCommand request, CancellationToken cancellationToken)
        {
            if (!_context.Categories.Any())
            {
                throw new Exception("No categories found!");
            }

            var data = await _context.Categories
                .AsNoTracking()
                .OrderBy(a => a.CreatedAt)
                .ToListAsync(cancellationToken);

            return data;
        }
    }
}