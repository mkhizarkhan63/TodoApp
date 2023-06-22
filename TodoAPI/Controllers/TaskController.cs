using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TodoAPI.Models;
using TodoAPI.Repository;
using TodoAPI.Static;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _tasks;
        public TaskController(ITaskRepository tasks)
        {
            _tasks = tasks;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Response res = new Response();
            try
            {
                res.status = 200;
                res.data = _tasks.GetAllTasks().ToList();
                return Ok(res);

            }
            catch (Exception ex)
            {

                res.msg = ex.Message;
                res.status = 500;
                return BadRequest(res);
            }
        }

        [HttpGet("GetTaskById")]
        public IActionResult GetTaskById(int id)
        {
            Response res = new Response();

            try
            {
                TodoTask data = _tasks.GetTaskById(id);
                if (data != null)
                {
                    res.flag = true;
                    res.data = data;
                    res.msg = "";
                    res.status = 200;
                }
                else
                {
                    res.flag = false;
                    res.msg = "Not Found";
                    res.status = 200;
                }
                return Ok(res);
            }
            catch (Exception ex)
            {
                res.msg = ex.Message;
                res.status = 500;
                return BadRequest(res);
            }

        }


        [HttpPost("AddTask")]
        public IActionResult AddTask([FromBody] TodoTask data)
        {
            Response res = new Response();

            try
            {
                bool check = _tasks.AddTasks(data);
                if (check)
                {
                    res.flag = check;
                    res.msg = "Task Added Successfully";
                    res.status = 200;
                }
                else
                {
                    res.flag = check;
                    res.msg = "Not Added Successfully";
                    res.status = 200;
                }
                return Ok(res);
            }
            catch (Exception ex)
            {
                res.msg = ex.Message;
                res.status = 500;
                return BadRequest(res);
            }
        }

        [HttpPost("EditTask")]
        public IActionResult EditTask([FromBody] TodoTask data)
        {
            Response res = new Response();
            try
            {
                bool flag = _tasks.UpdateTasks(data);
                if (flag)
                {
                    res.flag = flag;
                    res.msg = "Task Updated Successfully";
                    res.status = 200;
                }
                else
                {
                    res.flag = flag;
                    res.msg = "Task Not Updated Successfully";
                    res.status = 200;
                }

                return Ok(res);
            }
            catch (Exception ex)
            {

                res.msg = ex.Message;
                res.status = 500;
                return BadRequest(res);
            }
        }

        [HttpGet("DeleteTask")]
        public IActionResult DeleteTask(int id)
        {
            Response res = new Response();
            try
            {
                bool flag = _tasks.DeleteTasks(id);
                if (flag)
                {
                    res.flag = flag;
                    res.msg = "Task Deleted Successfully";
                    res.status = 200;

                }
                else
                {
                    res.flag = flag;
                    res.msg = "Something went wrong";
                    res.status = 200;
                }
                return Ok(res);
            }
            catch (Exception ex)
            {
                res.msg = ex.Message;
                res.status = 500;
                return BadRequest(res);
            }
        }
    }
}
