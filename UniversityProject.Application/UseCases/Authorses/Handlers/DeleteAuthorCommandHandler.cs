using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Application.UseCases.Authorses.Commands;
using UniversityProject.Domain.Entities;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Authorses.Handlers
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, Author>
    {
        private readonly DataContext _context;

        public DeleteAuthorCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Author> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            
            var author = await _context.Authors.FirstOrDefaultAsync(x=>x.Id==request.Id);
            if (author == null)
            {
                throw new Exception("Not found");
            }

           _context.Authors.Remove(author);
           await _context.SaveChangesAsync(cancellationToken);

            return author;



        }
    }
}
