using Microsoft.AspNetCore.Mvc;
using Mission8.Models;
using System.Linq;

public class HomeController : Controller
{
    private ITaskRepository _repo;

    public HomeController(ITaskRepository temp)
    {
        _repo = temp; // No more errors!
    }

    public IActionResult Quadrants()
    {
        // This will now pull the tasks from the repository
        var tasks = _repo.TaskItems.Where(x => x.Completed == false).ToList();
        return View(tasks);
    }

    [HttpGet]
    public IActionResult AddEditTask()
    {
        // Pass the categories to the view for the dropdown
        ViewBag.Categories = _repo.Categories.ToList();

        return View(new TaskItem()); // Return an empty task object
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        // Find the specific task to edit
        var task = _repo.TaskItems.Single(x => x.TaskId == id);

        // Still need categories for the dropdown on the edit page
        ViewBag.Categories = _repo.Categories.ToList();

        return View("AddEditTask", task);
    }

    [HttpPost]
    public IActionResult AddEditTask(TaskItem response)
    {
        if (ModelState.IsValid)
        {
            if (response.TaskId == 0)
            {
                _repo.AddTask(response); // New task
            }
            else
            {
                _repo.UpdateTask(response); // Existing task
            }
            return RedirectToAction("Quadrants");
        }

        // If data is invalid, send back to form with categories re-loaded
        ViewBag.Categories = _repo.Categories.ToList();
        return View(response);
    }

    [HttpPost]
    public IActionResult CompleteTask(int id)
    {
        var task = _repo.TaskItems.Single(x => x.TaskId == id);
        task.Completed = true;
        _repo.UpdateTask(task);
        return RedirectToAction("Quadrants");
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        // Directly call repository delete by id
        _repo.DeleteTask(id);

        return RedirectToAction("Quadrants");
    }
}