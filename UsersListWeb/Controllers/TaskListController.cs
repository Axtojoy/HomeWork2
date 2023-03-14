using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UsersListLogic;
using UsersListWeb.Models;
using UsersListWeb.Models.TasksList;
using UsersListWeb.Models.UsersList;

namespace UsersListWeb.Controllers
{
    public class TaskListController : Controller
    {
        private readonly TaskListService _taskService;

        public TaskListController(TaskListService taskService)
        {
            _taskService = taskService;
        }
        public IActionResult ReviewTasksList([FromQuery(Name = "page")] int page, [FromQuery(Name = "page-size")] int size)
        {
            if (size == 0)
                size = 10;
            var skip = page * size;

            var taskList = _taskService.Get(skip, size);

            var model = new TasksListViewModel(taskList, page, size);
            return View(model);
        }

    }
}
