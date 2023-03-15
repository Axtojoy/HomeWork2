using Microsoft.AspNetCore.Mvc;
using UsersList.DAL.Domain.Users;
using UsersList.Logic.Models.TasksList;
using UsersListLogic;
using UsersListLogic.Models.UsersList;
using UsersListWeb.Models.TasksList;
using UsersListWeb.Models.UsersList;

namespace UsersListWeb.Controllers
{
    public class TasksController : Controller
    {
        private readonly TaskService _taskService;

        public TasksController(TaskService taskService)
        {
            _taskService = taskService;
        }
        public IActionResult CreateTask()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTask(TaskCreateViewModel task)
        {
            var userId = _taskService.Create(new TaskCreateDTO()
            {
                Description = task.Description,
                Subject = task.Subject,
                //IdUser = task.IdUser

            });

            return RedirectToAction("CreateUser", "Users", new { id = userId });
        }

        [HttpGet]
        public IActionResult ChangeTask(int id)
        {
            var task = _taskService.Get(id);
            var taskModel = new TaskViewModel(task);
            return View(taskModel);
        }

        [HttpPost]
        public IActionResult ChangeTask(TaskChangeViewModel task)
        {
            var taskId = _taskService.Update(new UserslistChangeDTO()
            {
                Id = task.Id,
                Description = task.Description,
                Subject = task.Subject,
                IdUser = task.IdUser
            });
            return RedirectToAction("ChangeTask", new { Id = taskId });
        }

    }
}
