using Microsoft.EntityFrameworkCore;
using ProjectManagement.Entities;

namespace ProjectManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext
        (
            DbContextOptions<ApplicationDbContext> options
        ) : base(options)
        {
        }

        public DbSet<Project> Projects => Set<Project>();

        public DbSet<ProjectStatus> ProjectStatuses => Set<ProjectStatus>();

        public DbSet<TaskItem> Tasks => Set<TaskItem>();

        //   public DbSet<TaskStatus> TaskStatuses => Set<TaskStatus>();

        public DbSet<ProjectManagement.Entities.TaskStatus> TaskStatuses
            => Set<ProjectManagement.Entities.TaskStatus>();

        public DbSet<TaskPriority> TaskPriorities => Set<TaskPriority>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Project -> ProjectStatus

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Status)
                .WithMany(s => s.Projects)
                .HasForeignKey(p => p.StatusId);

            // Task -> Project

            modelBuilder.Entity<TaskItem>()
                .HasOne(t => t.Project)
                .WithMany(p => p.Tasks)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            // Task -> Status

            modelBuilder.Entity<TaskItem>()
                .HasOne(t => t.Status)
                .WithMany(s => s.Tasks)
                .HasForeignKey(t => t.StatusId);

            // Task -> Priority

            modelBuilder.Entity<TaskItem>()
                .HasOne(t => t.Priority)
                .WithMany(p => p.Tasks)
                .HasForeignKey(t => t.PriorityId);
        }
    }
}