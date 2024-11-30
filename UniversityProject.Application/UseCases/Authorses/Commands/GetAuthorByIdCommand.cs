using MediatR;
using UniversityProject.Domain.Entities;

namespace UniversityProject.Application.UseCases.Authorses.Commands;

public class GetAuthorByIdCommand : IRequest<Author>
{
    public int Id { get; set; }
}