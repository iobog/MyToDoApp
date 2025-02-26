using System.ComponentModel.DataAnnotations;

namespace MyToDoApp.Dtos;


public partial class TaskCreateDto
{
    [Required]
    public string Title { get; set; } = null!;

    public string? Description { get; set; }
    
    public string? Notes { get; set; }


}
