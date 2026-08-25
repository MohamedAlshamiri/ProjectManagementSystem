using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Entities
{
    public class TaskStatus
    {
        public int Id { get; set; }


        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;


        [Required]
        [StringLength(100)]
        public string NameAr { get; set; } = string.Empty;


        public ICollection<TaskItem> Tasks { get; set; }
            = new List<TaskItem>();
    }
}