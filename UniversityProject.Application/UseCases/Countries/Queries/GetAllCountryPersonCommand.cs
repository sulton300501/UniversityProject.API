using MediatR;
using UniversityProject.Domain.Entities.Auth;

namespace UniversityProject.Application.UseCases.Countries.Queries
{
    public class GetAllCountryPersonCommand : IRequest<List<ApplicationUser>>
    {
    }
}
