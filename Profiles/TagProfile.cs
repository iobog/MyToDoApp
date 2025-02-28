using AutoMapper;
using MyToDoApp.Dtos.TagDto;
using MyToDoApp.Models;

namespace MyToDoApp.Profiles;


// public class TagProfile :Profile
// {
//     public TagProfile()
//     {  
//        // source --> target
//        CreateMap<TTag,TagReadDto>();
//    }
// }

public class TagProfile : Profile
{
  public TagProfile()
  {
    CreateMap<TTag,TagReadDto>();
    CreateMap<TagCreateDto,TTag>();
    CreateMap<TagUpdateDto,TTag>();
    CreateMap<TTag,TagUpdateDto>();
  }

}