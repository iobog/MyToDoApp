


using AutoMapper;
using Azure;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MyToDoApp.Dtos.TagDto;
using MyToDoApp.Models;

[Route("api/tags")]
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
    return Ok(_mapper.Map<IEnumerable<TagReadDto>>(await _db.TTags.ToListAsync()));
  }

  [HttpGet("{id}",Name = "GetTagById")]
  public async Task<ActionResult<TagReadDto>> GetTagById(int id)
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
  

  [HttpPost]
  public async Task<ActionResult<TagReadDto>> CreateTag(TagCreateDto tagCreateDto)
  {
    try
    {
      var tagModel = _mapper.Map<TTag>(tagCreateDto);
      await _db.AddAsync(tagModel);
      await _db.SaveChangesAsync();

      var tagRead = _mapper.Map<TagReadDto>(tagModel);

      return CreatedAtRoute(nameof(GetTagById),new {Id = tagRead.Id},tagRead);

    }
    catch(Exception e)
    {
      return StatusCode(StatusCodes.Status500InternalServerError,e.Message);
    }
  }

  [HttpPut("{id}")]
  public async Task<ActionResult>UpdateTag(int id, TagUpdateDto tagUpdateDto)
  {
    try
    {
      var tag = await _db.TTags
        .Where(_ => _.Id == id)
        .FirstOrDefaultAsync();

      if (tag == null)
        return NotFound();

      _mapper.Map(tagUpdateDto,tag);
      _db.Update(tag);
      await _db.SaveChangesAsync();

      return NoContent();

    }
    catch (Exception e)
    {
      return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
    }
  }

  [HttpPatch("{id}")]
  public async Task<ActionResult> PartialTagUpdate(int id, JsonPatchDocument<TagUpdateDto> jsonPatchDocument)
  {
    try
    {
      var tag = await _db.TTags
        .Where(_ => _.Id == id)
        .FirstOrDefaultAsync();
      
      if(tag == null)
      {
        return NotFound();
      }

      var tagToPatch = _mapper.Map<TagUpdateDto>(tag);
      jsonPatchDocument.ApplyTo(tagToPatch,ModelState);

      if(!TryValidateModel(tagToPatch))
      {
        return ValidationProblem(ModelState);
      }

      _mapper.Map(tagToPatch,tag);
      _db.Update(tag);
      await _db.SaveChangesAsync();

      return NoContent();


    }
    catch (Exception e)
    {
      return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
    }
  }

  [HttpDelete("{id}")]
  public async Task<ActionResult> DeleteTagAsync(int id)
  {
    TTag tag1 = new();

    var tag = await _db.TTags
      .Where(_ => _.Id == id)
      .FirstOrDefaultAsync();

    if(tag == null) 
    {
      return NotFound();
    }
    _db.Remove(tag);
    await _db.SaveChangesAsync();

    return NoContent();

  }

}