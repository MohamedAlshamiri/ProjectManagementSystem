using Microsoft.EntityFrameworkCore;
using ProjectManagement.Entities;

namespace ProjectManagement.Data
{
    /// <summary>
    /// Development-friendly database initialization for the local learning project.
    /// It does not overwrite existing data; it only creates the database when needed
    /// and inserts missing lookup rows.
    /// </summary>
    public static class DatabaseInitializer
    {
        public static async Task InitializeAsync(ApplicationDbContext db)
        {
            await db.Database.EnsureCreatedAsync();

            if (!await db.ProjectStatuses.AnyAsync())
            {
                db.ProjectStatuses.AddRange(
                    new ProjectStatus { Name = "Planning", NameAr = "قيد التخطيط" },
                    new ProjectStatus { Name = "In Progress", NameAr = "قيد التنفيذ" },
                    new ProjectStatus { Name = "Completed", NameAr = "مكتمل" });
            }

            if (!await db.TaskStatuses.AnyAsync())
            {
                db.TaskStatuses.AddRange(
                    new ProjectManagement.Entities.TaskStatus { Name = "To Do", NameAr = "جديدة" },
                    new ProjectManagement.Entities.TaskStatus { Name = "In Progress", NameAr = "قيد التنفيذ" },
                    new ProjectManagement.Entities.TaskStatus { Name = "Completed", NameAr = "مكتملة" });
            }

            if (!await db.TaskPriorities.AnyAsync())
            {
                db.TaskPriorities.AddRange(
                    new TaskPriority { Name = "Low", NameAr = "منخفضة", SortOrder = 1 },
                    new TaskPriority { Name = "Medium", NameAr = "متوسطة", SortOrder = 2 },
                    new TaskPriority { Name = "High", NameAr = "عالية", SortOrder = 3 });
            }

            await db.SaveChangesAsync();
        }
    }
}
