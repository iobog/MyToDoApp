using MyToDoApp.Models;

namespace MyToDoApp.Data;


public class SqlToDoRepo : IToDoRepo
{
    private readonly ApplicationDbContext _context;

    public SqlToDoRepo(ApplicationDbContext context)
    {
        _context = context;
    }


    public void CreateTask(Ttask task)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Ttask> GetAllTasks() =>
        //return _context.Ttasks.ToList();
        [.. _context.Tasks];

    public Ttask GetTaskById(int id) =>
        _context.Tasks.FirstOrDefault(p => p.Id == id);
    

}