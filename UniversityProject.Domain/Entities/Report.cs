using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Entities.Auth;

namespace UniversityProject.Domain.Entities
{
    public class Report
    {
        public int Id { get; set; }
        public string Page_name { get; set; }
        public string Description { get; set;}
        public DateTime Created_at { get; set; }
        public bool Is_deleted { get; set; }
       



    }
}
