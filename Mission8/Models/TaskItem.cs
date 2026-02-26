using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission8.Models;

public partial class TaskItem
{
    [Required]
    [Key]
    public int TaskId { get; set; }

    public string? TaskName { get; set; }

    public DateOnly? DueDate { get; set; }

    [Required]
    public int Quadrant { get; set; }

    public int? CategoryId { get; set; }

    [Required]
    public bool? Completed { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public virtual Category? Category { get; set; }
}
