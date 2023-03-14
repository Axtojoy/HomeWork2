using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersListLogic;
using UsersListWeb.Models.TasksList;

namespace UsersListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskListConroller : ControllerBase
    {
        private readonly TaskListService _taskListService;

        public TaskListConroller(TaskListService taskListService)
        {
            _taskListService = taskListService;
        }

        [HttpGet("Filter")]
        public ActionResult<TasksListModel> Filter([FromQuery] int skip, [FromQuery] int take)
        {
            if (take < 0)
                take = 10;
            var taskList = _taskListService.Get(skip, take);

            var model = new TasksListModel(taskList, skip, take);

            return Ok(model);
        }
    }
}
