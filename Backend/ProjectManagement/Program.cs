using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data;
using ProjectManagement.Extensions;
using ProjectManagement.Mapping;
using ProjectManagement.Repositories.Interfaces;
using ProjectManagement.Repositories.Implementations;
using ProjectManagement.Services.Interfaces;
using ProjectManagement.Services.Implementations;

namespace ProjectManagement
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // =====================================================
            // Add services to the container.
            // =====================================================

            // Controllers
            builder.Services.AddControllers();

            // CORS: allow the Angular development server to call the API.
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AngularDev", policy =>
                {
                    policy.WithOrigins(
                              "http://localhost:4200",
                              "https://localhost:4200",
                              "http://127.0.0.1:4200",
                              "https://127.0.0.1:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });


            // =====================================================
            // Entity Framework Core
            // =====================================================

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));


            // =====================================================
            // AutoMapper
            // =====================================================

            builder.Services.AddAutoMapper(typeof(MappingProfile));


            // =====================================================
            // Repository Pattern
            // =====================================================

            builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

            builder.Services.AddScoped<ITaskRepository, TaskRepository>();


            // =====================================================
            // Service Layer
            // =====================================================

            builder.Services.AddScoped<IProjectService, ProjectService>();

            builder.Services.AddScoped<ITaskService, TaskService>();


            // =====================================================
            // Swagger / OpenAPI
            // =====================================================

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();


            // =====================================================
            // Build Application
            // =====================================================

            var app = builder.Build();

            // Development-only local database initialization.
            if (app.Environment.IsDevelopment())
            {
                using var scope = app.Services.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                await DatabaseInitializer.InitializeAsync(db);
            }


            // =====================================================
            // Configure the HTTP request pipeline.
            // =====================================================

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();

                app.UseSwaggerUI();
            }

            // =====================================================
            // Global Exception Middleware
            // =====================================================

            app.UseGlobalExceptionMiddleware();

            app.UseCors("AngularDev");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}