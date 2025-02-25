namespace MyToDoApp.Dtos;


public partial class TaskCreateDto
{

    public string Title { get; set; } = null!;

    public string? Description { get; set; }
    
    public string? Notes { get; set; }


}
