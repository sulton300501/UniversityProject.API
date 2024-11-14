using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Application.UseCases.Books.Commands;
using UniversityProject.Domain.Entities;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Books.Handlers
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Book>
    {
        private readonly DataContext _context;

        public DeleteBookCommandHandler(DataContext context)
        {
            _context = context;
        }
        public async Task<Book> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {

            var data = await _context.Books.FirstOrDefaultAsync(x => x.Id == request.BookId);
            if (data == null)
            {
                throw new Exception("not found");
            }


             _context.Books.Remove(data);
             await _context.SaveChangesAsync();

            return data;




        }
    }
}
