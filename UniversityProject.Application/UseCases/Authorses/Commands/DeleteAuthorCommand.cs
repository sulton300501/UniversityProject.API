using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Entities;

namespace UniversityProject.Application.UseCases.Authorses.Commands
{
    public class DeleteAuthorCommand : IRequest<Author>
    {
        public int AuthorId { get; set; }

    }
}
