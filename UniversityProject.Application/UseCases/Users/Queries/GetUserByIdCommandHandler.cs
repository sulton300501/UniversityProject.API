using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityProject.Application.UseCases.Users.Commands;
using UniversityProject.Domain.Entities.DTOs;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Users.Queries
{
    public class GetUserByIdCommandHandler(DataContext context)
        : IRequestHandler<GetUserByIdCommand, UserDTO>
    {
        public Task<UserDTO> Handle(GetUserByIdCommand request, CancellationToken cancellationToken)
        {
            var user = context.Users
                .Include(a => a.Report)
                .Include(a => a.Country)
                .FirstOrDefault(a=> a.Id == request.Id);
            
            if (user == null)
                throw new Exception("Not found!");

            var newData = new UserDTO
            {
                Id = user.Id,
                FullName = user.FullName,
                PhoneNumber = user.PhoneNumber,
                PictureUrl = user.PictureUrl,
                Email = user.Email,
                CreatedAt = user.CreatedAt,
                Report = user.Report,
                Country = user.Country,
            };

            return Task.FromResult(newData);
        }
    }
}
