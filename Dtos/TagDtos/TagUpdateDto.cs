using System.ComponentModel.DataAnnotations;

namespace MyToDoApp.Dtos.TagDto;


public class TagUpdateDto
{
  [Required]
  public required string Name{set;get;}

}