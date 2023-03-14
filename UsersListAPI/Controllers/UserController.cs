using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersList.Logic.Models.TasksList;
using UsersListLogic;
using UsersListLogic.Models.UsersList;
using UsersListWeb.Models.TasksList;
using UsersListWeb.Models.UsersList;

namespace UsersListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpGet("{id}")]
        public ActionResult<UserModel> Get(int id)
        {
            var user = _userService.Get(id);

            var userModel = new UserModel(user);

            return Ok(userModel);
        }

        [HttpPost("")]
        public IActionResult Create(UsersListCreateModel task)
        {
            var taskId = _userService.Create(new UsersListCreateDTO()
            {
                FirstName = task.FirstName,
                LastName = task.LastName,
                Email = task.Email,
                

            });

            return Ok(taskId);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(UsersListChangeModel task)
        {

            var taskId = _userService.Update(new UsersListChangeDTO()
            {
               Id = task.Id,
               FirstName = task.FirstName,
               LastName = task.LastName,
                Email = task.Email,
               IdTask = task.IdTask
               


            });

            return Ok(taskId);
        }
    }
}
