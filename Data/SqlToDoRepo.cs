using MyToDoApp.Models;

namespace MyToDoApp.Data;


public class SqlToDoRepo : IToDoRepo
{
    private readonly AppDbContext _context;

    public SqlToDoRepo(AppDbContext context)
    {
        _context = context;
    }


    public void CreateTask(TTask task)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TTask> GetAllTasks() {
        return _context.TTasks.ToList();
        //return [.. _context.Tasks];
    }

    public TTask GetTaskById(int id) {
        return _context.TTasks.FirstOrDefault(p => p.Id == id);
    }


}