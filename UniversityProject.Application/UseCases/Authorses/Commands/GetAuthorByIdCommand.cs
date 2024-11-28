using MediatR;
using UniversityProject.Domain.Entities;

namespace UniversityProject.Application.UseCases.Authorses.Commands;

public class GetAuthorByIdCommand : IRequest<Author>
{
    public int id { get; set; }
}