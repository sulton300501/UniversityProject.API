using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityProject.Domain.Entities.DTOs;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Books.Queries;

public class GetBookCategoriesQueryHandler(DataContext context)
    : IRequestHandler<GetBookCategoriesQuery, List<BookCategoryDTO>>
{
    public async Task<List<BookCategoryDTO>> Handle
        (GetBookCategoriesQuery request, CancellationToken cancellationToken)
    {
        var bookCategories = await context.Books
            .Include(b => b.Category)
            .ToListAsync(cancellationToken);

        return null;
    }
}