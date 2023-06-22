using System.Collections;
using System.Collections.Generic;
using TodoAPI.Models;

namespace TodoAPI.Repository
{
    public interface ITaskRepository
    {
        public IEnumerable<TodoTask> GetAllTasks();
        public bool AddTasks(TodoTask data);
        public bool UpdateTasks(TodoTask data);
        public bool DeleteTasks(int id);
        public TodoTask GetTaskById(int id);
    }
}
