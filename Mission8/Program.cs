using Microsoft.EntityFrameworkCore;
using Mission8.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Reads the appsettings.json and registers the TaskDatabaseContext as a service
// with the connection info packaged into DbContextOptions
builder.Services.AddDbContext<TaskDatabaseContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("TaskItemConnection")));

// give each HTTP request an instance of EFTaskRepository
// EFTaskRepository = basically the logic that runs the different methods we need for the project
builder.Services.AddScoped<ITaskRepository, EFTaskRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
