using System.Text.Json.Serialization;

namespace UniversityProject.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public DateTime CreatedAt { get; set; }
        
        [JsonIgnore]
        public DateTime? DeletedAt { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
