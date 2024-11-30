namespace UniversityProject.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public int Length { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string PictureUrl { get; set; }
        public int Count { get; set; }
        public int AuthorId { get; set; }
        public int CountryId { get; set; }
        public int CategoryId { get; set; }

        public Author Author { get; set; }
        public Country Country { get; set; }
        public ICollection<Category> Category { get; set; }
    }

}
