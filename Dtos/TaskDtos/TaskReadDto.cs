namespace MyToDoApp.Dtos.TaskDtos;

public class TaskReadDto
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }


    public string? Notes { get; set; }

    public DateTime? CreatedAt { get; set; }

}
