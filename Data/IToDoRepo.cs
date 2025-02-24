namespace MyToDoApp.Data;


public interface IToDoRepo
{
    bool SaveChanges();

    void CreateTask(); 
}