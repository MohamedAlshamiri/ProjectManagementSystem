using AutoMapper;
using ProjectManagement.DTOs.Tasks;
using ProjectManagement.Entities;
using ProjectManagement.Repositories.Interfaces;
using ProjectManagement.Responses;
using ProjectManagement.Services.Interfaces;

namespace ProjectManagement.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;


        public TaskService
        (
            ITaskRepository taskRepository,
            IProjectRepository projectRepository,
            IMapper mapper
        )
        {
            _taskRepository = taskRepository;
            _projectRepository = projectRepository;
            _mapper = mapper;
        }



        // ==========================================
        // Get All Tasks
        // Pagination + Filtering + Searching + Sorting
        // ==========================================

        public async Task<PagedResponse<TaskDto>> GetAllAsync(
            int? statusId,
            int? projectId,
            string? search,
            string? sortBy,
            string? sortOrder,
            int pageNumber,
            int pageSize)
        {
            var pagedTasks =
                await _taskRepository.GetAllAsync(
                    statusId,
                    projectId,
                    search,
                    sortBy,
                    sortOrder,
                    pageNumber,
                    pageSize);

            return new PagedResponse<TaskDto>
            {
                Items =
                    _mapper.Map<IEnumerable<TaskDto>>(
                        pagedTasks.Items),

                PageNumber =
                    pagedTasks.PageNumber,

                PageSize =
                    pagedTasks.PageSize,

                TotalCount =
                    pagedTasks.TotalCount
            };
        }




        // ==========================================
        // Get Task By Id
        // ==========================================

        public async Task<TaskDto?> GetByIdAsync(int id)
        {
            var task =
                await _taskRepository.GetByIdAsync(id);


            if (task == null)
                return null;


            return _mapper.Map<TaskDto>(task);
        }




        // ==========================================
        // Get Tasks By Project
        // ==========================================

        public async Task<IEnumerable<TaskDto>> GetByProjectIdAsync(
            int projectId)
        {
            var projectExists =
                await _projectRepository.ExistsAsync(projectId);


            if (!projectExists)
                return Enumerable.Empty<TaskDto>();


            var tasks =
                await _taskRepository.GetByProjectIdAsync(projectId);


            return _mapper.Map<IEnumerable<TaskDto>>(tasks);
        }




        // ==========================================
        // Create Task
        // ==========================================

        public async Task<TaskDto> CreateAsync(
            CreateTaskDto dto)
        {
            var projectExists =
                await _projectRepository.ExistsAsync(dto.ProjectId);


            if (!projectExists)
                throw new Exception("Project does not exist");


            var task =
                _mapper.Map<TaskItem>(dto);


            task.CreatedAt =
                DateTime.Now;


            await _taskRepository.AddAsync(task);


            await _taskRepository.SaveChangesAsync();

            // Reload navigations so the response contains Project/Status/Priority names.
            var createdTask = await _taskRepository.GetByIdAsync(task.Id);
            return _mapper.Map<TaskDto>(createdTask);
        }




        // ==========================================
        // Update Task
        // ==========================================

        public async Task<bool> UpdateAsync(
            int id,
            UpdateTaskDto dto)
        {
            var task =
                await _taskRepository.GetByIdAsync(id);


            if (task == null)
                return false;


            _mapper.Map(dto, task);


            task.UpdatedAt =
                DateTime.Now;


            _taskRepository.Update(task);


            await _taskRepository.SaveChangesAsync();


            return true;
        }




        // ==========================================
        // Delete Task
        // ==========================================

        public async Task<bool> DeleteAsync(int id)
        {
            var task =
                await _taskRepository.GetByIdAsync(id);


            if (task == null)
                return false;


            _taskRepository.Delete(task);


            await _taskRepository.SaveChangesAsync();


            return true;
        }
    }
}