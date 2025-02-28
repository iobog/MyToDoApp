using AutoMapper;
using MyToDoApp.Dtos;
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
  }

}