using System.Collections.Generic;

namespace Mission8.Models2
{
    public interface ITaskRepository
    {
        List<TaskItem> Tasks { get; }
        List<Category> Categories { get; }

        void AddTask(TaskItem task);
        void UpdateTask(TaskItem task);
        void DeleteTask(TaskItem task);
    }
}
