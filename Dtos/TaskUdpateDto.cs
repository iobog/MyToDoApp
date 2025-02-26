using System.ComponentModel.DataAnnotations;

namespace MyToDoApp.Dtos;


public partial class TaskUpdateDto
{

    [Required ]
    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public bool? IsCompleted { get; set; }

    public string? Notes { get; set; }

    public DateTime? DeletedAt { get; set; }


}
