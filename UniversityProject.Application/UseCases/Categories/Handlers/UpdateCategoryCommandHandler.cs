using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Category>
    {
        private readonly DataContext _context;

        public UpdateCategoryCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Category> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {

            var data = await _context.Categories.FirstOrDefaultAsync(x => x.Id == request.CategoryId);
            if (data == null)
            {
                throw new Exception("not found");
            }

            data.Count = request.Count;
            data.Name = request.Name;

            await _context.Categories.AddAsync(data);
            await _context.SaveChangesAsync();
            return data;
        }
    }
}
