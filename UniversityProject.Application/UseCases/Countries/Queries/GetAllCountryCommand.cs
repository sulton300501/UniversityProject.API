using MediatR;
using UniversityProject.Domain.Entities;

namespace UniversityProject.Application.UseCases.Countries.Queries
{
    public class GetAllCountryCommand : IRequest<IEnumerable<Country>>
    {

    }
}
