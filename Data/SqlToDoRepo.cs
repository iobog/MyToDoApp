using MyToDoApp.Models;

namespace MyToDoApp.Data;


public class SqlToDoRepo : IToDoRepo
{
    private readonly AppDbContext _context;

    public SqlToDoRepo(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<TTask> GetAllTasks() {
        return _context.TTasks.ToList();
        //return [.. _context.Tasks];
    }

    public TTask GetTaskById(int id) {
        //return _context.TTasks.FirstOrDefault(p => p.Id == id);
        return _context.TTasks.FirstOrDefault(p => p.Id == id)!;
    }

    public void CreateTask(TTask task)
    {
        if(task == null)
        {
            throw new ArgumentNullException(nameof(task));
        }
        _context.TTasks.Add(task);

        
    }

    public bool SaveChanges()
    {
        return (_context.SaveChanges()>= 0 );

    }

    public void UpdateTask(TTask task)
    {
        //Nothing
    }

    public void DeleteTask(TTask task)
    {
        if(task == null)
        {
            throw new ArgumentNullException(nameof(task));
        }
        _context.TTasks.Remove(task);

    }
}