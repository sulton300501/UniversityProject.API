using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Entities;

namespace UniversityProject.Application.UseCases.Countries.Commands
{
    public class CreateCountryCommand : IRequest<Country>
    {
        public string CountryName { get; set; }
        public int Count { get; set; }
    }
}
