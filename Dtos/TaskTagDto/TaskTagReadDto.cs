// namespace MyToDoApp.Dtos.TaskTagDto;

// public class TaskTagReadDto
// {
//   public int Id { get; set; }
//   public int TaskId { get; set; }
//   public int TagId { get; set; }
// }


namespace MyToDoApp.Dtos.TaskTagDto;


public class TaskTagReadDto
{
  public int Id { get; set; } 
  public string Title { get; set; } = string.Empty; 
  public string? Description { get; set; } 
  public DateTime? CreatedAt { get; set; } 
  public string TagName { get; set; } = string.Empty;
}


