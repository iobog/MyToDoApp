using System.Threading.Tasks;
using AutoMapper;
using Azure;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MyToDoApp.Data;
using MyToDoApp.Dtos.TaskDtos;
using MyToDoApp.Models;

namespace MyToDoApp.Controller;


[Route("api/tasks")]
[ApiController]
public class ToDoController : ControllerBase
{
  private readonly IToDoRepo _repository;
  private readonly AppDbContext _db;
  private readonly IMapper _mapper;

  public ToDoController(IToDoRepo toDoRepo, AppDbContext db, IMapper mapper)
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
  [HttpPut("{id}")]
  public async Task<ActionResult> UpdateTaskAsync(int id, TaskUpdateDto taskUpdateDto)
  {
    
    //var taskModelFromRepo = _db.F(id);
    try
    {
      var task = await _db.TTasks
        .Where(_ => _.Id == id)
        .FirstOrDefaultAsync();

      if(task == null) 
      {
        return NotFound();
      }

      _mapper.Map(taskUpdateDto,task);

      _db.Update(task);

      await _db.SaveChangesAsync();

      return NoContent();

    }
    catch(Exception e)
    {
      return StatusCode(StatusCodes.Status500InternalServerError,e.Message);
    }

  }


  //PATCH api/commands/{id}
  [HttpPatch("{id}")]
  public async Task<ActionResult> PartialTaskUpdateAsync(int id,JsonPatchDocument<TaskUpdateDto> patchDoc)
  {
    try
    {
      var taskModelFromDb = await _db.TTasks
        .Where(_ => _.Id == id)
        .FirstOrDefaultAsync();

      if(taskModelFromDb == null) 
      {
        return NotFound();
      }

      var taskToPatch = _mapper.Map<TaskUpdateDto>(taskModelFromDb);
      patchDoc.ApplyTo(taskToPatch,ModelState);

      if(!TryValidateModel(taskToPatch))
      {
        return ValidationProblem(ModelState);
      }

      _mapper.Map(taskToPatch,taskModelFromDb);
      _db.Update(taskModelFromDb);
      await _db.SaveChangesAsync();

      return NoContent();
    }
    catch(Exception e)
    {
      return StatusCode(StatusCodes.Status500InternalServerError,e.Message);
    }
  }


  [HttpDelete("{id}")]
  public async Task<ActionResult> DeleteTaskAsync(int id)
  {
    var taskModelFromDb = await _db.TTasks
      .Where(_ => _.Id == id)
      .FirstOrDefaultAsync();

    if(taskModelFromDb == null) 
    {
      return NotFound();
    }
    _db.Remove(taskModelFromDb);
    await _db.SaveChangesAsync();

    return NoContent();

  }

}