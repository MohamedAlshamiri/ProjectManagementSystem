using Microsoft.AspNetCore.Mvc;
using ProjectManagement.DTOs.Projects;
using ProjectManagement.Services.Interfaces;

namespace ProjectManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        // ==========================================
        // GET: api/projects
        // ==========================================

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projects = await _projectService.GetAllAsync();

            return Ok(projects);
        }

        // ==========================================
        // GET: api/projects/{id}
        // ==========================================

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var project = await _projectService.GetByIdAsync(id);

            if (project == null)
                return NotFound();

            return Ok(project);
        }

        // ==========================================
        // POST: api/projects
        // ==========================================

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var project = await _projectService.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = project.Id },
                project);
        }

        // ==========================================
        // PUT: api/projects/{id}
        // ==========================================

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update
        (
            int id,
            UpdateProjectDto dto
        )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated =
                await _projectService.UpdateAsync(id, dto);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        // ==========================================
        // DELETE: api/projects/{id}
        // ==========================================

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted =
                await _projectService.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}