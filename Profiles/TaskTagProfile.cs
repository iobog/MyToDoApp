using AutoMapper;
using MyToDoApp.Dtos.TagDto;
using MyToDoApp.Models;
using MyToDoApp.Dtos.TaskTagDto;

namespace MyToDoApp.Profiles;


// public class TagProfile :Profile
// {
//     public TagProfile()
//     {  
//        // source --> target
//        CreateMap<TTag,TagReadDto>();
//    }
// }

public class TaskTagProfile : Profile
{
  public TaskTagProfile()
  {
    // CreateMap<TTaskTag, TaskTagDto>()
    //   .ForMember(dest => dest.TaskTitle, opt => opt.MapFrom(src => src.Task.Title))
    //   .ForMember(dest => dest.TagName, opt => opt.MapFrom(src => src.Tag.Name));


    // CreateMap<TTaskTag,TaskTagReadDto>();
    // CreateMap<TaskTagCreateDto,TTag>();
    // CreateMap<TaskTagUpdateDto,TTag>();
    // CreateMap<TTag,TaskTagUpdateDto>();

    CreateMap<TTaskTag, TaskTagReadDto>()
      .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Task.Title))
      .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Task.Description))
      .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.Task.CreatedAt))
      .ForMember(dest => dest.TagName, opt => opt.MapFrom(src => src.Tag.Name));
    

    



  }

}