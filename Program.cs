using Microsoft.EntityFrameworkCore;
using MyToDoApp.Data;
using MyToDoApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Add Database Context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IToDoRepo, SqlToDoRepo>();

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();

app.Run();
