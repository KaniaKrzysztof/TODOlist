using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskApi.Controllers
{
    [Route("api/task")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskContext _context;

        public TaskController(TaskContext context)
        {
            _context = context;

            //if (_context.TaskItems.Count() == 0)
            //{
            //    // Create a new TaskItem if collection is empty,
            //    // which means you can't delete all TaskItems.
            //    _context.TaskItems.Add(new TaskItem { Content = "Item1" });
            //    _context.SaveChanges();
            //}
        }

        // GET: api/task
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetTaskItems()
        {
            return await _context.TaskItems.ToListAsync();
        }

        // GET: api/task/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetTaskItem(long id)
        {
            var taskItem = await _context.TaskItems.FindAsync(id);

            if (taskItem == null)
            {
                return NotFound();
            }

            return taskItem;
        }

        // POST: api/task
        [HttpPost]
        public async Task<ActionResult<TaskItem>> PostTaskItem(TaskItem item)
        {
            _context.TaskItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTaskItem), new { id = item.Id }, item);
        }

        // DELETE: api/Task/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskItem(long id)
        {
            var TaskItem = await _context.TaskItems.FindAsync(id);

            if (TaskItem == null)
            {
                return NotFound();
            }

            _context.TaskItems.Remove(TaskItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
