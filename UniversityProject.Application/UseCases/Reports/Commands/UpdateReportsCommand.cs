﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Entities;

namespace UniversityProject.Application.UseCases.Reports.Commands
{
    public class UpdateReportsCommand : IRequest<Report>
    {
        public int ReportsId { get; set; }
        public string PageName { get; set; }
        public string Description { get; set; }
        public int ApplicationUserId { get; set; }
    }
}
