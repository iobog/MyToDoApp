using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyToDoApp.Data;
using MyToDoApp.Models;

namespace MyToDoApp.Controller;


[Route("api/tasks")]
[ApiController]
public class ToDoController : ControllerBase
{
  private readonly IToDoRepo _repository;
  private readonly AppDbContext _db;

  public ToDoController(IToDoRepo toDoRepo,
      AppDbContext db)
  {
    _repository = toDoRepo;
    _db = db;
  }

  [HttpGet]
  public async Task<ActionResult<IEnumerable<TTask>>> GetAllTasks()
  {
    return Ok(await _db.TTasks.ToListAsync());
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<TTask>> GetTaskById(int id)
  {
    try
    {
      var task = await _db.TTasks
        .Where(_ => _.Id == id)
        .FirstOrDefaultAsync();

      if (task == null)
        return NotFound();

      return Ok(task);
    }
    catch (Exception e)
    {
      return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
    }
  }


}