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


  [HttpGet]
  public async Task<ActionResult<IEnumerable<TaskTagReadDto>>> GetTaskTags()
  {
    var taskTags = await _db.TTaskTags
      .Include(tt => tt.Task)
      .Include(tt => tt.Tag)
      .ToListAsync();

    return Ok(_mapper.Map<IEnumerable<TaskTagReadDto>>(taskTags));
  }


  [HttpGet("{id}",Name = "GetTaskTagById")]
  public async Task<ActionResult<TaskTagReadDto>>GetTaskTagById(int id)
  {
    var taskTag = await _db.TTaskTags.Where(_ => _.Id == id)
    .Include(tt => tt.Task)
    .Include(tt => tt.Tag)
    .FirstOrDefaultAsync();

    if(taskTag == null)
    {
      return NotFound();
    }

    return Ok(_mapper.Map<TaskTagReadDto>(taskTag));
  }

  [HttpPost]
  public async Task<ActionResult<>>



  // {
  //   id: " TaskTag_id"
  //   title: this is fromm task
  //   description: this is from task
  //   created_at this is from task
  //    TagName:-->this is from tag 
     
  // }



  






}