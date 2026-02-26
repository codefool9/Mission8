using Microsoft.AspNetCore.Mvc;
using Mission8.Models2;

public class HomeController : Controller
{
    private ITaskRepository _repo;

    public HomeController(ITaskRepository temp)
    {
        _repo = temp; // No more errors!
    }

    public IActionResult Quadrants()
    {
        // This will now pull the "Fake" tasks from your stub
        var tasks = _repo.Tasks.Where(x => x.Completed == false).ToList();
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
        var task = _repo.Tasks.Single(x => x.TaskId == id);

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
    public IActionResult Delete(int id)
    {
        var task = _repo.Tasks.Single(x => x.TaskId == id);
        _repo.DeleteTask(task);

        return RedirectToAction("Quadrants");
    }
}