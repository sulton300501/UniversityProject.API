using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Entities;

namespace UniversityProject.Application.UseCases.Authorses.Queries
{
    public class GetAllAuthorCommand : IRequest<List<Author>>
    {
    }
}
