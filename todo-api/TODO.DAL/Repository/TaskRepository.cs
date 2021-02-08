using System.Collections.Generic;
using System.Linq;
using TODO.Model;

namespace TODO.DAL.Repository
{
    /// <summary>
    /// Repository for Task related DB operations
    /// </summary>
    public class TaskRepository : IDataRepository<Task>
    {
        private readonly TaskContext _taskContext;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public TaskRepository(TaskContext context)
        {
            _taskContext = context;
        }

        /// <summary>
        /// Get All Tasks
        /// </summary>
        /// <returns>Task Object</returns>
        public IEnumerable<Task> GetAll()
        {
            return _taskContext.Tasks;
        }

        /// <summary>
        /// Get a Task using task Id
        /// </summary>
        /// <param name="id">Task Id</param>
        /// <returns>Task Object</returns>
        public Task Get(int id)
        {
            return _taskContext.Tasks
                  .FirstOrDefault(e => e.Id == id);
        }

        /// <summary>
        /// Insert a new Task record
        /// </summary>
        /// <param name="entity">Task to be Inserted</param>
        /// <returns></returns>
        public async System.Threading.Tasks.Task<int> Add(Task entity)
        {
            _taskContext.Tasks.Add(entity);
            return await _taskContext.SaveChangesAsync();
        }

        /// <summary>
        /// Update a particular Task
        /// </summary>
        /// <param name="task">Existing Task</param>
        /// <param name="entity">Modified Task</param>
        /// <returns></returns>
        public async System.Threading.Tasks.Task<int> Update(Task task, Task entity)
        {
            task.Name = entity.Name;
            task.DueDate = entity.DueDate;
            task.Priority = entity.Priority;
            return await _taskContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete a Task
        /// </summary>
        /// <param name="task">Task to be removed</param>
        /// <returns></returns>
        public async System.Threading.Tasks.Task<int> Delete(Task task)
        {
            _taskContext.Tasks.Remove(task);
            return await _taskContext.SaveChangesAsync();
        }
    }
}
