using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityProject.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Category_id { get; set; }
        public List<Category> Categories { get; set; }
        public int author_id { get; set; }
        public List<Author> Authors { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public int Length { get; set; }
        public DateTime Created_at { get; set; }
        public bool Is_deleted { get; set; }
        public string PictureUrl { get; set; }
        public int country_id { get; set; }
        public List<Country> Country { get; set; }
        
        public int Count { get; set; }

    }
}
