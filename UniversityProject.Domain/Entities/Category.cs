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
        public DateTime? Is_deleted { get; set; }
        public List<Book> Books { get; set; }

    }
}
