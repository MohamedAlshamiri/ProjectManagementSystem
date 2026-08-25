using AutoMapper;
using ProjectManagement.DTOs.Projects;
using ProjectManagement.Entities;
using ProjectManagement.Repositories.Interfaces;
using ProjectManagement.Services.Interfaces;

namespace ProjectManagement.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public ProjectService
        (
            IProjectRepository projectRepository,
            IMapper mapper
        )
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        // ==========================================
        // Get All Projects
        // ==========================================

        public async Task<IEnumerable<ProjectDto>> GetAllAsync()
        {
            var projects = await _projectRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<ProjectDto>>(projects);
        }

        // ==========================================
        // Get Project By Id
        // ==========================================

        public async Task<ProjectDto?> GetByIdAsync(int id)
        {
            var project = await _projectRepository.GetByIdAsync(id);

            if (project == null)
                return null;

            return _mapper.Map<ProjectDto>(project);
        }

        // ==========================================
        // Create Project
        // ==========================================

        public async Task<ProjectDto> CreateAsync(CreateProjectDto dto)
        {
            var project = _mapper.Map<Project>(dto);

            project.CreatedAt = DateTime.Now;

            await _projectRepository.AddAsync(project);

            await _projectRepository.SaveChangesAsync();

            // Reload Status/Tasks navigations so the response is complete.
            var createdProject = await _projectRepository.GetByIdAsync(project.Id);
            return _mapper.Map<ProjectDto>(createdProject);
        }

        // ==========================================
        // Update Project
        // ==========================================

        public async Task<bool> UpdateAsync(int id, UpdateProjectDto dto)
        {
            var project = await _projectRepository.GetByIdAsync(id);

            if (project == null)
                return false;

            _mapper.Map(dto, project);

            project.UpdatedAt = DateTime.Now;

            _projectRepository.Update(project);

            await _projectRepository.SaveChangesAsync();

            return true;
        }

        // ==========================================
        // Delete Project
        // ==========================================

        public async Task<bool> DeleteAsync(int id)
        {
            var project = await _projectRepository.GetByIdAsync(id);

            if (project == null)
                return false;

            _projectRepository.Delete(project);

            await _projectRepository.SaveChangesAsync();

            return true;
        }
    }
}