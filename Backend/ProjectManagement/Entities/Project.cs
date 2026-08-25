using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Entities
{
    public class Project
    {
        public int Id { get; set; }


        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;


        [StringLength(1000)]
        public string? Description { get; set; }


        public int StatusId { get; set; }


        public DateTime? StartDate { get; set; }


        public DateTime? EndDate { get; set; }


        public DateTime CreatedAt { get; set; }
            = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }


        // Navigation Properties

        public ProjectStatus? Status { get; set; }


        public ICollection<TaskItem> Tasks { get; set; }
            = new List<TaskItem>();
    }
}