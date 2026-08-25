namespace ProjectManagement.DTOs.Tasks
{
    public class TaskQueryParameters
    {
        public int? ProjectId { get; set; }

        public int? StatusId { get; set; }

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;
    }
}