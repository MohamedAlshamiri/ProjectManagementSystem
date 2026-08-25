using AutoMapper;
using ProjectManagement.DTOs.Projects;
using ProjectManagement.DTOs.Tasks;
using ProjectManagement.Entities;

namespace ProjectManagement.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // ===========================
            // Project
            // ===========================

            CreateMap<Project, ProjectDto>()
                .ForMember(
                    dest => dest.StatusName,
                    opt => opt.MapFrom(src => src.Status!.Name)
                )
                .ForMember(
                    dest => dest.TasksCount,
                    opt => opt.MapFrom(src => src.Tasks.Count)
                );

            CreateMap<CreateProjectDto, Project>();

            CreateMap<UpdateProjectDto, Project>();


            // ===========================
            // Task
            // ===========================

            CreateMap<TaskItem, TaskDto>()
                .ForMember(
                    dest => dest.ProjectName,
                    opt => opt.MapFrom(src => src.Project!.Name)
                )
                .ForMember(
                    dest => dest.StatusName,
                    opt => opt.MapFrom(src => src.Status!.Name)
                )
                .ForMember(
                    dest => dest.PriorityName,
                    opt => opt.MapFrom(src => src.Priority!.Name)
                );

            CreateMap<CreateTaskDto, TaskItem>();

            CreateMap<UpdateTaskDto, TaskItem>();
        }
    }
}