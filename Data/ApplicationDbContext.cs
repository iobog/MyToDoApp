namespace MyToDoApp.Data;

using Microsoft.EntityFrameworkCore;
using MyToDoApp.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Ttask> Ttasks { get; set; }
}
