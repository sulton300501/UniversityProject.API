using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityProject.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Deleted_at { get; set; }

        public ICollection<Book> Books { get; set; }
       

    }
}
