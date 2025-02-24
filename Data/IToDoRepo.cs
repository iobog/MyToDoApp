using MyToDoApp.Models;

namespace MyToDoApp.Data;


public interface IToDoRepo
{
   //bool SaveChanges();

    Ttask GetTaskById(int id);
    IEnumerable<Ttask> GetAllTasks();

    void CreateTask(Ttask task);
    //void UpdateTask()
}