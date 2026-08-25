using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Entities
{
    public class TaskItem
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }


        [Required]
        [StringLength(300)]
        public string Title { get; set; } = string.Empty;


        [StringLength(1000)]
        public string? Description { get; set; }


        public int StatusId { get; set; }


        public int PriorityId { get; set; }


        public DateTime? DueDate { get; set; }


        public DateTime CreatedAt { get; set; }
            = DateTime.Now;


        public DateTime? UpdatedAt { get; set; }


        // Navigation Properties

        public Project? Project { get; set; }


        public TaskStatus? Status { get; set; }


        public TaskPriority? Priority { get; set; }
    }
}