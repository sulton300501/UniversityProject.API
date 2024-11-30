namespace UniversityProject.Domain.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string? BirthDate { get; set; }
        public string BioWikipediya { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? PictureUrl { get; set; }
        public int CountryId { get; set; }

        public Country Country { get; set; }
        public ICollection<Book> Books { get; set; }
    }

}
