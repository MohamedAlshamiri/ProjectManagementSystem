namespace ProjectManagement.DTOs.Tasks
{
    public class TaskDto
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public string ProjectName { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int StatusId { get; set; }

        public string StatusName { get; set; } = string.Empty;

        public int PriorityId { get; set; }

        public string PriorityName { get; set; } = string.Empty;

        public DateTime? DueDate { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
