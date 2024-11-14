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
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Category>
    {

        private readonly DataContext _context;

        public CreateCategoryCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var data = new Category()
            {
                Name = request.Name,
                Count = request.Count,
              


            };

          
            await _context.Categories.AddAsync(data);
            await _context.SaveChangesAsync();


            return data;
        }
    }
}
