using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Entities;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Books.Queries
{
    public class GetAllBookCommandHandler(DataContext context)
        : IRequestHandler<GetAllBooksCommand, List<Book>>
    {
        public async Task<List<Book>> Handle(GetAllBooksCommand request, CancellationToken cancellationToken)
        {
            var data = await context.Books
                .ToListAsync(cancellationToken);
            return data;
        }
    }
}
