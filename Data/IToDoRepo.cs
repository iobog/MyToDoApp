using MyToDoApp.Models;

namespace MyToDoApp.Data;


public interface IToDoRepo
{
   bool SaveChanges();

    TTask GetTaskById(int id);
    IEnumerable<TTask> GetAllTasks();

    void CreateTask(TTask task);
    //void UpdateTask()
}