using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data;
using ProjectManagement.Entities;
using ProjectManagement.Repositories.Interfaces;

namespace ProjectManagement.Repositories.Implementations
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // ==========================================
        // Get All Projects
        // ==========================================

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _context.Projects
                .Include(p => p.Status)
                .Include(p => p.Tasks)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }

        // ==========================================
        // Get Project By Id
        // ==========================================

        public async Task<Project?> GetByIdAsync(int id)
        {
            return await _context.Projects
                .Include(p => p.Status)
                .Include(p => p.Tasks)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        // ==========================================
        // Check Exists
        // ==========================================

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Projects
                .AnyAsync(p => p.Id == id);
        }

        // ==========================================
        // Add
        // ==========================================

        public async Task AddAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
        }

        // ==========================================
        // Update
        // ==========================================

        public void Update(Project project)
        {
            _context.Projects.Update(project);
        }

        // ==========================================
        // Delete
        // ==========================================

        public void Delete(Project project)
        {
            _context.Projects.Remove(project);
        }

        // ==========================================
        // Save Changes
        // ==========================================

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}