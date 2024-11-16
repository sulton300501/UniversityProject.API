using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Entities;
using UniversityProject.Domain.Entities.Auth;

namespace UniversityProject.Application.UseCases.Countries.Queries
{
    public class GetAllCountryPersonCommand : IRequest<List<ApplicationUser>>
    {
    }
}
