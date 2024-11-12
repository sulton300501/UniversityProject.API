using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Entities.Auth;

namespace UniversityProject.Domain.Entities
{
    public class Country
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public DateTime Created_at { get; set; }
        public bool Is_deleted { get; set; }
       
       
     
    }
}
