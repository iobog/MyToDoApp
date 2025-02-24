using System;
using System.Collections.Generic;

namespace MyToDoApp.Models;

public partial class Ttask
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public bool? IsCompleted { get; set; }

    public string? Notes { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }
}
