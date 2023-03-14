using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersList.Logic.Models.TasksList;
using UsersListLogic;
using UsersListWeb.Models.TasksList;

namespace UsersListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _taskService;
        

        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("{id}")]
        public ActionResult<TaskModel> Get(int id)
        {
            var task = _taskService.Get(id);

            var taskModel = new TaskModel(task);

            return Ok(taskModel);
        }

        [HttpPost("")]
        public IActionResult Create(TaskCreateModel task)
        {
            var taskId = _taskService.Create(new TaskCreateDTO()
            {
                Subject = task.Subject,
                Description = task.Description,
                
            });

            return Ok(taskId);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(TaskChangeModel task)
        {

            var taskId = _taskService.Update(new UserslistChangeDTO()
            {
                Id = task.Id,
                Subject = task.Subject,
                Description = task.Description,
                IdUser = task.Id
               
            });

            return Ok(taskId);
        }
    }
}
