namespace Mission8.Models;

public interface ITaskRepository
{
    List<TaskItem> TaskItems { get; }
    List<Category> Categories { get; }
    public void AddTask(TaskItem task);
    public void EditTask(TaskItem task);
    public void DeleteTask(int id);
}