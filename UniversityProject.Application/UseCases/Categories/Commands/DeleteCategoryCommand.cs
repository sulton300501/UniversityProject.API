﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Entities;

namespace UniversityProject.Application.UseCases.Categories.Commands
{
    public class DeleteCategoryCommand : IRequest<Category>
    {
        public int CategoryId { get; set; }
    }
}
