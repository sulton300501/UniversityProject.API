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
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Category>
    {
        private readonly DataContext _context;

        public DeleteCategoryCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Category> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var data = await _context.Categories.FirstOrDefaultAsync(x => x.Id == request.CategoryId);
            if (data == null)
            {
                throw new Exception("Not found");
            }

            _context.Categories.Remove(data);
            await _context.SaveChangesAsync();



            return data;
        }
    }
}
