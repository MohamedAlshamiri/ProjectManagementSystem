using ProjectManagement.DTOs.Projects;

namespace ProjectManagement.Services.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDto>> GetAllAsync();

        Task<ProjectDto?> GetByIdAsync(int id);

        Task<ProjectDto> CreateAsync(CreateProjectDto dto);

        Task<bool> UpdateAsync(int id, UpdateProjectDto dto);

        Task<bool> DeleteAsync(int id);
    }
}