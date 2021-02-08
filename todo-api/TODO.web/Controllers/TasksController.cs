using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TODO.DAL.Repository;

namespace TODO.web.Controllers
{
    /// <summary>
    /// Controller takes care of all Task related operations
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly IDataRepository<Model.Task> _taskRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="taskRepository"></param>
        public TasksController(IDataRepository<Model.Task> taskRepository)
        {
            _taskRepository = taskRepository;
        }

        /// <summary>
        /// Get All Tasks
        /// </summary>
        /// <returns>List of Tasks</returns>
        [HttpGet]
        public IActionResult GetTasks()
        {
            try
            {
                var tasks = _taskRepository.GetAll();
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Insert a new Task
        /// </summary>
        /// <param name="task">Task Object</param>
        /// <returns>Task Object with Id updated</returns>
        [HttpPost]
        public async Task<IActionResult> AddTask([FromBody] Model.Task task)
        {
            try
            {
                if (task == null)
                {
                    return BadRequest("Task is null.");
                }

                await _taskRepository.Add(task);
                return Ok(task);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Update a particular Task
        /// </summary>
        /// <param name="id">Task Id</param>
        /// <param name="task">Modified Task Object</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] Model.Task task)
        {
            try
            {
                if (task == null)
                {
                    return BadRequest("Task is null.");
                }

                var taskToUpdate = _taskRepository.Get(id);
                if (taskToUpdate == null)
                {
                    return NotFound("The Task record couldn't be found.");
                }

                return Ok(await _taskRepository.Update(taskToUpdate, task));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Delete a Task
        /// </summary>
        /// <param name="id">Task id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            try
            {
                var task = _taskRepository.Get(id);
                if (task == null)
                {
                    return NotFound("The Task record couldn't be found.");
                }

                return Ok(await _taskRepository.Delete(task));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
