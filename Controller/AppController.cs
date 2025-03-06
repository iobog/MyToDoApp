using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MyToDoApp.Dtos.TaskTagDto;
using MyToDoApp.Models;

namespace MyToDoApp.Controller;


[Route("api/application")]
[ApiController]
public class AppController: ControllerBase
{
  private readonly AppDbContext _db;
  private readonly IMapper _mapper;

  public AppController(AppDbContext dbContext, IMapper mapper)
  {
    _db = dbContext;
    _mapper = mapper;
    
  }


  // [HttpGet]
  // public async Task<ActionResult<IEnumerable<TaskTagReadDto>>> GetAllTaskTags()
  // {
  //   return Ok(_mapper.Map<IEnumerable<TaskTagReadDto>>(await _db.TTaskTags.ToListAsync()));
  // }



  // {
  //   id: " TaskTag_id"
  //   title: this is fromm task
  //   description: this is from task
  //   created_at this is from task
  //    TagName:-->this is from tag 
     
  // }



  






}