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
  }

}