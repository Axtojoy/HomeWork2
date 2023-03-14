using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersListLogic;
using UsersListWeb.Models.TasksList;
using UsersListWeb.Models.UsersList;

namespace UsersListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersListController : ControllerBase
    {
        private readonly UsersListService _userService;

        public UsersListController(UsersListService userService)
        {
            _userService = userService;
        }
        [HttpGet("Filter")]
        public ActionResult<UsersListModel> Filter([FromQuery] int skip, [FromQuery] int take)
        {
            if (take < 0)
                take = 10;
            var taskList = _userService.Get(skip, take);

            var model = new UsersListModel(taskList, skip, take);

            return Ok(model);
        }
    }
}
