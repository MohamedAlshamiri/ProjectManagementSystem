using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.DTOs.Tasks
{
    public class CreateTaskDto
    {
        [Required]
        public int ProjectId { get; set; }


        [Required]
        [StringLength(300)]
        public string Title { get; set; } = string.Empty;


        [StringLength(1000)]
        public string? Description { get; set; }


        [Required]
        public int StatusId { get; set; }


        [Required]
        public int PriorityId { get; set; }


        public DateTime? DueDate { get; set; }
    }
}