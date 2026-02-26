namespace Mission8.Models2
{
    public class TaskItem
    {
        public int TaskId { get; set; }
        public string? TaskName { get; set; }
        public int Quadrant { get; set; }
        public bool Completed { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
