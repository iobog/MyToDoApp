


using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyToDoApp.Dtos;
using MyToDoApp.Models;

[Route("api/tag")]
[ApiController]
public class TagController:ControllerBase
{
  private readonly AppDbContext _db;
  private readonly IMapper _mapper;

  public TagController(AppDbContext dbContext, IMapper mapper)
  {
    _db = dbContext;
    _mapper = mapper;
    
  }

  [HttpGet]
  public async Task<ActionResult<IEnumerable<TagReadDto>>> GetAllTasks()
  {
    return Ok(_mapper.Map<IEnumerable<TagReadDto>>(await _db.TTasks.ToListAsync()));
  }

  [HttpGet("{id}",Name = "GetTagById")]
  public async Task<ActionResult<TagReadDto>> GetTaskById(int id)
  {
    try
    {
      var tag = await _db.TTags
        .Where(_ => _.Id == id)
        .FirstOrDefaultAsync();

      if (tag == null)
        return NotFound();

      return Ok(_mapper.Map<TagReadDto>(tag));
    }
    catch (Exception e)
    {
      return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
    }
  }

  






}