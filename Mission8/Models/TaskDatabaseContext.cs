using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mission8.Models;

public partial class TaskDatabaseContext : DbContext
{
    public TaskDatabaseContext()
    {
    }

    // This is what actually makes the connection between my database and the data
    // Receives the DbContextOptions and passes it up to EF Core's built in DbContext
    public TaskDatabaseContext(DbContextOptions<TaskDatabaseContext> options)
    
        // passing connection options up to EF Core's DbContext
        // we are handing EF Core the keys to our database connection
        // We just need to provide EF core with where the database is (appsettings.json)
        // What the data looks like (model classes)
        // How they relate (context file)
        : base(options)
    {
    }

    // This turns our database tables into usable C# objects that I can access throughout the project
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<TaskItem> TaskItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=TaskDatabase.sqlite");

    // This defines the relationships between the tables (CategoryId in TaskItem to CategoryId in Category)
    // This can also be done in the models folder, but since we scaffolded, it automatically did it this way
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");
        });

        modelBuilder.Entity<TaskItem>(entity =>
        {
            entity.HasKey(e => e.TaskId);

            entity.ToTable("TaskItem");

            entity.HasOne(d => d.Category).WithMany().HasForeignKey(d => d.CategoryId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
