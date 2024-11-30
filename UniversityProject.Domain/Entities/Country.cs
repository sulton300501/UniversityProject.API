using UniversityProject.Domain.Entities.Auth;

namespace UniversityProject.Domain.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public ICollection<Author> Author { get; set; }
        public ICollection<ApplicationUser> User { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
