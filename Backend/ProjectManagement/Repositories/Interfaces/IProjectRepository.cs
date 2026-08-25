using ProjectManagement.Entities;

namespace ProjectManagement.Repositories.Interfaces
{
    public interface IProjectRepository
    {
        // ==========================
        // Read
        // ==========================

        Task<IEnumerable<Project>> GetAllAsync();

        Task<Project?> GetByIdAsync(int id);

        Task<bool> ExistsAsync(int id);


        // ==========================
        // Write
        // ==========================

        Task AddAsync(Project project);

        void Update(Project project);

        void Delete(Project project);


        // ==========================
        // Save
        // ==========================

        Task SaveChangesAsync();
    }
}