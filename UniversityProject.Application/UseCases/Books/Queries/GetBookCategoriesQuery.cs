using MediatR;
using UniversityProject.Domain.Entities.DTOs;

namespace UniversityProject.Application.UseCases.Books.Queries;

public class GetBookCategoriesQuery:IRequest<List<BookCategoryDTO>>
{
    
}