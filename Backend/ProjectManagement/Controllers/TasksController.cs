using Microsoft.AspNetCore.Mvc;
using ProjectManagement.DTOs.Tasks;
using ProjectManagement.Services.Interfaces;

namespace ProjectManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // ==========================================
        // GET: api/tasks
        //
        // Examples:
        //
        // api/tasks
        // api/tasks?statusId=2
        // api/tasks?search=Angular
        // api/tasks?sortBy=priority&sortOrder=desc
        // api/tasks?pageNumber=1&pageSize=5
        //
        // ==========================================

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] int? statusId,
            [FromQuery] int? projectId,
            [FromQuery] string? search,
            [FromQuery] string? sortBy,
            [FromQuery] string? sortOrder,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            pageNumber = Math.Max(1, pageNumber);
            pageSize = Math.Clamp(pageSize, 1, 100);

            var tasks =
                await _taskService.GetAllAsync(
                    statusId,
                    projectId,
                    search,
                    sortBy,
                    sortOrder,
                    pageNumber,
                    pageSize);

            return Ok(tasks);
        }

        // ==========================================
        // GET: api/tasks/{id}
        // ==========================================

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _taskService.GetByIdAsync(id);

            if (task == null)
                return NotFound();

            return Ok(task);
        }

        // ==========================================
        // GET: api/tasks/project/{projectId}
        // ==========================================

        [HttpGet("project/{projectId:int}")]
        public async Task<IActionResult> GetByProject(int projectId)
        {
            var tasks = await _taskService.GetByProjectIdAsync(projectId);

            return Ok(tasks);
        }

        // ==========================================
        // POST: api/tasks
        // ==========================================

        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var task = await _taskService.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = task.Id },
                task);
        }

        // ==========================================
        // PUT: api/tasks/{id}
        // ==========================================

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(
            int id,
            UpdateTaskDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _taskService.UpdateAsync(id, dto);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        // ==========================================
        // DELETE: api/tasks/{id}
        // ==========================================

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _taskService.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}