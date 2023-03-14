using Microsoft.AspNetCore.Mvc;
using UsersListLogic.Models;
using UsersListLogic;
using UsersListWeb.Models.UsersList;
using System.Diagnostics;
using UsersListWeb.Models;

namespace UsersListWeb.Controllers
{

    public class UsersListController : Controller
    {
        private readonly UsersListService _usersListService;
        
        public UsersListController(UsersListService usersListService)
        {
            _usersListService = usersListService;
        }

        public IActionResult ReviewUsersList([FromQuery(Name = "page")] int page, [FromQuery(Name = "page-size")] int size)
        {
            if (size == 0)
                size = 10;
            var skip = page * size;

            var usersList = _usersListService.Get(skip, size);

            var model = new UsersListViewModel(usersList, page, size);
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
