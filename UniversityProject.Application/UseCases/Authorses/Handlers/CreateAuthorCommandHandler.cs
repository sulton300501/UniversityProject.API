using MediatR;
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
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommands, Author>
    {
        private readonly DataContext _context;

        public CreateAuthorCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Author> Handle(CreateAuthorCommands request, CancellationToken cancellationToken)
        {


            var files = request.Picture;



            var data = new Author()
            {
                Full_name = request.Full_name,
                Year = request.Year,
                Bio_wikipediya = request.Bio_wikipediya,
                Created_at = DateTime.UtcNow,
                Is_deleted = null,

            };

            return data;
            



        }
    }
}
