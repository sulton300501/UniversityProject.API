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
    
        public int category_id { get; set; }
        public Category Category { get; set; }

        public int author_id { get; set; }
        public Author Author { get; set; }

        public int countr_id { get; set; }
        public Country Country { get; set; }
      
        public int Year { get; set; }
        public string Description { get; set; }
        public int Length { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Is_deleted { get; set; }
        public string PictureUrl { get; set; }

     
        
        public int Count { get; set; }

    }
}
