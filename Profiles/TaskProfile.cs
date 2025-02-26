using AutoMapper;
using MyToDoApp.Dtos;
using MyToDoApp.Models;

namespace MyToDoApp.Profiles;


public class TaskProfile :Profile
{
    public TaskProfile()
    {  
       // source --> target
       CreateMap<TTask,TaskReadDto>();
       CreateMap<TaskCreateDto,TTask>();
       CreateMap<TaskUpdateDto,TTask>();
       CreateMap<TTask,TaskUpdateDto>();
    }
}