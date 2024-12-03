using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Application.UseCases.Categories.Commands;
using UniversityProject.Domain.Entities;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Categories.Handlers
{
    public class CreateCategoryCommandHandler(DataContext context)
        : IRequestHandler<CreateCategoryCommand, Category>
    {
        public async Task<Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var data = new Category()
            {
                Name = request.Name,
                Count = request.Count,
                CreatedAt = DateTime.UtcNow
            };
            
            await context.Categories.AddAsync(data, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            
            return data;
        }
    }
}
