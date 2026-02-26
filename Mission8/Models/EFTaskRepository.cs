namespace Mission8.Models;

public class EFTaskRepository : ITaskRepository
{
    // declares a variable, AT THIS POINT IT IS EMPTY, there is nothing here.
    private TaskDatabaseContext _context;
    
    // Using a constructor, we take our empty _context variable, and then pass in an instance of TaskDatabaseContext
    public EFTaskRepository(TaskDatabaseContext temp)
    {
        _context = temp;
    }

    // this creates a List of all the rows in the TaskItems table and the Categories table, allowing us to accesss it outside of this file
    public List<TaskItem> TaskItems => _context.TaskItems.ToList();
    public List<Category> Categories => _context.Categories.ToList();
    
    // add a task
    public void AddTask(TaskItem task)
    {
        // looks at the context file
        _context.TaskItems.Add(task);
        _context.SaveChanges();
    }

    // update a task
    public void UpdateTask(TaskItem task)
    {
        _context.TaskItems.Update(task);
        _context.SaveChanges();
    }

    // delete a task
    public void DeleteTask(int id)
    {
        var task = _context.TaskItems.Find(id);
        _context.TaskItems.Remove(task);
        _context.SaveChanges();
    }
}