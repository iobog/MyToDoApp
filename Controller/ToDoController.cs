using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MyToDoApp.Data;
using MyToDoApp.Dtos;
using MyToDoApp.Models;

namespace MyToDoApp.Controller;


[Route("api/tasks")]
[ApiController]
public class ToDoController : ControllerBase
{
  private readonly IToDoRepo _repository;
  private readonly AppDbContext _db;
  private readonly IMapper _mapper;

  public ToDoController(IToDoRepo toDoRepo,
    AppDbContext db, IMapper mapper)
  {
    _repository = toDoRepo;
    _db = db;
    _mapper = mapper;
  }

  [HttpGet]
  public async Task<ActionResult<IEnumerable<TaskReadDto>>> GetAllTasks()
  {
    return Ok(_mapper.Map<IEnumerable<TaskReadDto>>(await _db.TTasks.ToListAsync()));
  }

  [HttpGet("{id}",Name = "GetTaskById")]
  public async Task<ActionResult<TaskReadDto>> GetTaskById(int id)
  {
    try
    {
      var task = await _db.TTasks
        .Where(_ => _.Id == id)
        .FirstOrDefaultAsync();

      if (task == null)
        return NotFound();

      return Ok(_mapper.Map<TaskReadDto>(task));
    }
    catch (Exception e)
    {
      return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
    }
  }


  [HttpPost]
  public async Task<ActionResult<TaskReadDto>> CreateTask(TaskCreateDto taskCreateDto)
  {
    try
    {
      var taskModel = _mapper.Map<TTask>(taskCreateDto);
      await _db.AddAsync(taskModel);
      await _db.SaveChangesAsync();

      var taskReadDto = _mapper.Map<TaskReadDto>(taskModel);
      
      return CreatedAtRoute(nameof(GetTaskById),new {Id = taskReadDto.Id},taskReadDto);
      //return Ok(_mapper.Map<TaskReadDto>(taskModel));

    }
    catch(Exception e)
    {
      return StatusCode(StatusCodes.Status500InternalServerError,e.Message);
    }
  }
  // [HttpPost]
  // public ActionResult<TaskReadDto> CreateTask(TaskCreateDto taskCreateDto)
  // {
  //   try
  //   {
  //     var taskModel = _mapper.Map<TTask>(taskCreateDto);
  //     //await _db.AddAsync(taskModel);
  //     //await _db.SaveChangesAsync();
  //     _repository.CreateTask(taskModel);
  //     _repository.SaveChanges();

  //     return Ok(_mapper.Map<TaskReadDto>(taskModel));

  //   }
  //   catch (Exception e)
  //   {
  //     return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
  //   }
  // }



}