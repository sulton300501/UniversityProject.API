using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Entities;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Categories.Queries
{
    public class GetAllCategoryCommandHandler : IRequestHandler<GetAllCategoryCommand, List<Category>>
    {
        private readonly DataContext _context;

        public GetAllCategoryCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> Handle(GetAllCategoryCommand request, CancellationToken cancellationToken)
        {
            var data = await _context.Categories
                .Include(a=> a.Books)
                .ToListAsync(cancellationToken);
            return data;
        }
    }
}
