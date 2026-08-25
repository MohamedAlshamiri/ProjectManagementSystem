using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data;
using ProjectManagement.Entities;
using ProjectManagement.Repositories.Interfaces;
using ProjectManagement.Responses;

namespace ProjectManagement.Repositories.Implementations
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // ==========================================
        // Get All Tasks
        // Pagination + Filtering + Searching + Sorting
        // ==========================================

        public async Task<PagedResponse<TaskItem>> GetAllAsync(
            int? statusId,
            int? projectId,
            string? search,
            string? sortBy,
            string? sortOrder,
            int pageNumber,
            int pageSize)
        {
            var query = _context.Tasks
                .Include(t => t.Project)
                .Include(t => t.Status)
                .Include(t => t.Priority)
                .AsQueryable();

            // ==========================================
            // Filter By Status
            // ==========================================

            if (statusId.HasValue)
            {
                query = query.Where(t =>
                    t.StatusId == statusId.Value);
            }

            // ==========================================
            // Filter By Project
            // ==========================================

            if (projectId.HasValue)
            {
                query = query.Where(t =>
                    t.ProjectId == projectId.Value);
            }

            // ==========================================
            // Search
            // ==========================================

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();

                query = query.Where(t =>
                    t.Title.Contains(search) ||
                    (t.Description != null &&
                     t.Description.Contains(search)) ||
                    t.Project.Name.Contains(search));
            }

            // ==========================================
            // Sorting
            // ==========================================

            bool descending =
                string.Equals(
                    sortOrder,
                    "desc",
                    StringComparison.OrdinalIgnoreCase);

            switch (sortBy?.ToLower())
            {
                case "title":

                    query = descending
                        ? query.OrderByDescending(t => t.Title)
                        : query.OrderBy(t => t.Title);

                    break;

                case "priority":

                    query = descending
                        ? query.OrderByDescending(t => t.Priority.SortOrder)
                        : query.OrderBy(t => t.Priority.SortOrder);

                    break;

                case "duedate":

                    query = descending
                        ? query.OrderByDescending(t => t.DueDate)
                        : query.OrderBy(t => t.DueDate);

                    break;

                default:

                    query = descending
                        ? query.OrderByDescending(t => t.CreatedAt)
                        : query.OrderBy(t => t.CreatedAt);

                    break;
            }

            // ==========================================
            // Total Count
            // ==========================================

            var totalCount = await query.CountAsync();

            // ==========================================
            // Pagination
            // ==========================================

            var tasks = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // ==========================================
            // Return Response
            // ==========================================

            return new PagedResponse<TaskItem>
            {
                Items = tasks,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount
            };
        }

        // ==========================================
        // Get Task By Id
        // ==========================================

        public async Task<TaskItem?> GetByIdAsync(int id)
        {
            return await _context.Tasks
                .Include(t => t.Project)
                .Include(t => t.Status)
                .Include(t => t.Priority)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        // ==========================================
        // Get Tasks By Project
        // ==========================================

        public async Task<IEnumerable<TaskItem>> GetByProjectIdAsync(
            int projectId)
        {
            return await _context.Tasks
                .Where(t => t.ProjectId == projectId)
                .Include(t => t.Project)
                .Include(t => t.Status)
                .Include(t => t.Priority)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }

        // ==========================================
        // Check Exists
        // ==========================================

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Tasks
                .AnyAsync(t => t.Id == id);
        }

        // ==========================================
        // Add
        // ==========================================

        public async Task AddAsync(TaskItem task)
        {
            await _context.Tasks.AddAsync(task);
        }

        // ==========================================
        // Update
        // ==========================================

        public void Update(TaskItem task)
        {
            _context.Tasks.Update(task);
        }

        // ==========================================
        // Delete
        // ==========================================

        public void Delete(TaskItem task)
        {
            _context.Tasks.Remove(task);
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