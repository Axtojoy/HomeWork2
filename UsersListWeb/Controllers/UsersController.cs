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

        public UsersController(UserService userService)
        {
            _userService = userService;
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
        public IActionResult CreateUser(UsersListCreateViewModel user) 
        {
            var userId = _userService.Create(new UsersListCreateDTO()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                //IdTask = user.IdTask,
                

            });

            return View();
        }
        

        [HttpGet]
        public IActionResult ChangeUsersList(int id)
        {
            var user = _userService.Get(id);
            var userModel = new UserViewModel(user);
            return View(userModel);
        }

        [HttpPost]
        public IActionResult ChangeUsersList(UsersListChangeViewModel user)
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
