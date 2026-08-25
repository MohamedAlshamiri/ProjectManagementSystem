using ProjectManagement.Entities;
using ProjectManagement.Responses;

namespace ProjectManagement.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        // ==========================
        // Read
        // ==========================

        Task<PagedResponse<TaskItem>> GetAllAsync(
            int? statusId,
            int? projectId,
            string? search,
            string? sortBy,
            string? sortOrder,
            int pageNumber,
            int pageSize);

        Task<TaskItem?> GetByIdAsync(int id);

        Task<IEnumerable<TaskItem>> GetByProjectIdAsync(
            int projectId);

        Task<bool> ExistsAsync(int id);

        // ==========================
        // Write
        // ==========================

        Task AddAsync(TaskItem task);

        void Update(TaskItem task);

        void Delete(TaskItem task);

        // ==========================
        // Save
        // ==========================

        Task SaveChangesAsync();
    }
}