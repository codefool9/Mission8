using System.Collections.Generic;

namespace Mission8.Models2
{
    public class EFTaskRepository : ITaskRepository
    {
        // Fake data so you can test your Controller logic
        public List<TaskItem> Tasks => new List<TaskItem>
        {
            new TaskItem { TaskId = 1, TaskName = "Test Task 1", Quadrant = 1, Completed = false },
            new TaskItem { TaskId = 2, TaskName = "Test Task 2", Quadrant = 2, Completed = false }
        };

        public List<Category> Categories => new List<Category>
        {
            new Category { CategoryId = 1, CategoryName = "Home" },
            new Category { CategoryId = 2, CategoryName = "Work" }
        };

        public void AddTask(TaskItem task) { /* Temporary Empty */ }
        public void UpdateTask(TaskItem task) { /* Temporary Empty */ }
        public void DeleteTask(TaskItem task) { /* Temporary Empty */ }
    }
}
