
using System.ComponentModel.DataAnnotations;

namespace MyToDoApp.Dtos.TagDto;


public class TagCreateDto
{
  [Required]
  public required string Name{set;get;}
}