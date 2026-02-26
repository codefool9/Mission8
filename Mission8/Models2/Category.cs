using System.Collections.Generic;

namespace Mission8.Models2
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public List<TaskItem>? Tasks { get; set; }
    }
}
