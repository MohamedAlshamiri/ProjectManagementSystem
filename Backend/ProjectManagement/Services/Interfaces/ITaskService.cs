using ProjectManagement.DTOs.Tasks;
using ProjectManagement.Responses;

namespace ProjectManagement.Services.Interfaces
{
    public interface ITaskService
    {
        // ==========================
        // Read
        // ==========================

        Task<PagedResponse<TaskDto>> GetAllAsync(
            int? statusId,
            int? projectId,
            string? search,
            string? sortBy,
            string? sortOrder,
            int pageNumber,
            int pageSize);

        Task<TaskDto?> GetByIdAsync(int id);

        Task<IEnumerable<TaskDto>> GetByProjectIdAsync(
            int projectId);

        // ==========================
        // Write
        // ==========================

        Task<TaskDto> CreateAsync(
            CreateTaskDto dto);

        Task<bool> UpdateAsync(
            int id,
            UpdateTaskDto dto);

        Task<bool> DeleteAsync(
            int id);
    }
}