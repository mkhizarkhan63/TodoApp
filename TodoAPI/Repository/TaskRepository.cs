using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using TodoAPI.Context;
using TodoAPI.Models;

namespace TodoAPI.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly APIDbContext _context;
        public TaskRepository(APIDbContext context)
        {
            _context = context;
        }
        public bool AddTasks(TodoTask data)
        {
            bool flag = false;
            try
            {
                data.status = 0;
                data.createdDateTime = DateTime.Now.ToString("yyyy-MMM-dd"); //2023-Apr-13
                _context.TodoTasks.Add(data);
                int res = _context.SaveChanges();
                if (res > 0)
                    flag = true;
                return flag;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool DeleteTasks(int id)
        {
            bool flag = false;
            try
            {
                TodoTask task = _context.TodoTasks.FirstOrDefault(t => t.Id == id);
                if (task != null)
                {
                    _context.TodoTasks.Remove(task);
                    var res = _context.SaveChanges();
                    if (res > 0)
                        flag = true;
                }
                return flag;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public TodoTask GetTaskById(int id)
        {
            try
            {
                TodoTask task = _context.TodoTasks.FirstOrDefault(x => x.Id == id);
                return task;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public IEnumerable<TodoTask> GetAllTasks()
        {
            try
            {
                IList<TodoTask> ls = new List<TodoTask>();
                ls = _context.TodoTasks.OrderBy(x => x.createdDateTime).ToList();
                return ls;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool UpdateTasks(TodoTask data)
        {
            bool flag = false;
            try
            {
                TodoTask task = _context.TodoTasks.FirstOrDefault(x => x.Id == data.Id);
                if (task != null)
                {
                    task.Task = data.Task;
                    task.status = data.status;
                    // task.createdDateTime = DateTime.Now;
                    task.updatedDateTime = DateTime.Now.ToString("yyyy-MMM-dd"); 

                    _context.TodoTasks.Update(task);
                    var res = _context.SaveChanges();
                    if (res > 0)
                        flag = true;
                }

                return flag;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
