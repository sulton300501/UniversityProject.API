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
    public class GetAllBookCommandHandler : IRequestHandler<GetAllBooksCommand, List<Book>>
    {

        private readonly DataContext _context;

        public GetAllBookCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> Handle(GetAllBooksCommand request, CancellationToken cancellationToken)
        {


            var data = await _context.Books.ToListAsync();
            return data;


        }
    }
}
