using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityProject.Domain.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Full_name { get; set; }
        public string? Year { get; set; }
        public string Bio_wikipediya { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Is_deleted { get; set; }
       
        public string? PictureUrl { get; set; }

        public List<Book> Books { get; set; }


    }
}
