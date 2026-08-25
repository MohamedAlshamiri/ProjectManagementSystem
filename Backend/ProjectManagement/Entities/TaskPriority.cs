using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Entities
{
    public class TaskPriority
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string NameAr { get; set; } = string.Empty;

        public byte SortOrder { get; set; }

        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}