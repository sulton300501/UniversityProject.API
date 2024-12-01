using System.Text.Json.Serialization;
using UniversityProject.Domain.Entities.Auth;

namespace UniversityProject.Domain.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Count { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        // Circular reference muammosini oldini olish uchun:
        [JsonIgnore]
        public ICollection<Author> Author { get; set; }
        // Circular reference muammosini oldini olish uchun:
        [JsonIgnore]
        public ICollection<ApplicationUser> User { get; set; }
        // Circular reference muammosini oldini olish uchun:
        [JsonIgnore]
        public ICollection<Book> Books { get; set; }
    }
}
