using UniversityProject.Domain.Entities.Auth;

namespace UniversityProject.Domain.Entities
{
    public class Report
    {
        public int Id { get; set; }
        public string PageName { get; set; }
        public string Description { get; set;}
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int ApplicationUserId { get; set; }
        public  ApplicationUser User { get; set; }
    }
}
