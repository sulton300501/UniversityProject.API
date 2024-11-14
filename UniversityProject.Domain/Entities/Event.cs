using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityProject.Domain.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Deleted_at { get; set; }
        public string Description { get; set; }
        public DateTime Date {  get; set; }

    }
}
