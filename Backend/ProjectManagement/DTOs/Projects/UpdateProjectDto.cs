using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.DTOs.Projects
{
    public class UpdateProjectDto
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;


        [StringLength(1000)]
        public string? Description { get; set; }


        [Required]
        public int StatusId { get; set; }


        public DateTime? StartDate { get; set; }


        public DateTime? EndDate { get; set; }
    }
}