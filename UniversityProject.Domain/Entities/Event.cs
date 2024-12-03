using System.Text.Json.Serialization;
using UniversityProject.Domain.Entities.Auth;

namespace UniversityProject.Domain.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        
        [JsonIgnore]
        public DateTime? DeletedAt { get; set; }
        public string Description { get; set; }
        public DateTime Date {  get; set; }
        public int ApplicationUserId { get; set; }

        public virtual ApplicationUser CreatedBy { get; set; }
    }
}
