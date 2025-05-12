using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/tasks")]
[Authorize]
public class TasksController : ControllerBase
{
    private readonly List<Task> _tasks;

    public TasksController(List<Task> tasks)
    {
        _tasks = tasks;
    }

    [HttpPost]
    public IActionResult CreateTask([FromBody] Task task)
    {
        task.Id = _tasks.Count + 1;
        _tasks.Add(task);
        return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
    }

    [HttpGet("{id}")]
    public IActionResult GetTaskById(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        return task == null ? NotFound() : Ok(task);
    }

    [HttpGet("user/{userId}")]
    [Authorize(Roles = "Admin")] // Only admins can view all user tasks
    public IActionResult GetTasksByUser(int userId)
    {
        return Ok(_tasks.Where(t => t.AssignedUserId == userId));
    }
}