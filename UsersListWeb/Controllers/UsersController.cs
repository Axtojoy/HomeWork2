using Microsoft.AspNetCore.Mvc;
using UsersList.DAL.Domain.Users;
using UsersListLogic;
using UsersListLogic.Models.UsersList;
using UsersListWeb.Models.UsersList;

namespace UsersListWeb.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserService _userService;
        private readonly TaskService _taskService;

        public UsersController(UserService userService, TaskService taskService)
        {
            _userService = userService;
            _taskService = taskService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateUser()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CreateUser(UserCreateViewModel user) 
        {
            _userService.Create(new UsersListCreateDTO()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                //IdTask = user.IdTask,
                

            });
           
            return RedirectToAction("ReviewUsersList", "UsersList");
            
        }
        

        [HttpGet]
        public IActionResult ChangeUsersList(int id)
        {
            var user = _userService.Get(id);
            var userModel = new UserViewModel(user);
            return View(userModel);
        }

        [HttpPost]
        public IActionResult ChangeUsersList(UsersChangeViewModel user)
        {
            var userId = _userService.Update(new UsersListChangeDTO()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                IdTask = user.IdTask,
            });
            return RedirectToAction("ChangeUsersList", new { Id = userId });
        }
    }
}
