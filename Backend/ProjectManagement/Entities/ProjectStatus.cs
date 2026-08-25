using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Entities
{
    public class ProjectStatus
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string NameAr { get; set; } = string.Empty;

        // Navigation Property

        public ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}