using System.Collections.Generic;
using UsersList.Logic;
using UsersList.Logic.Models.UsersList;
using UsersListLogic.Models.UsersList;
using UsersListWeb.Models.UsersList;

namespace UsersListWeb.Models.UsersList
{
    public class UsersListViewModel
    {
        public List<UserViewModel> Users { get; set; }
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }

        public bool CanBack { get; set; }
        public bool CanForward { get; set; }
        public UsersListViewModel() {
            Users = new List<UserViewModel>();
        }

        public UsersListViewModel(UsersListDTO usersList, int page, int size)
        {
            Users = new List<UserViewModel>();
            foreach(UserDTO user in usersList.Users)
            {
                Users.Add(new UserViewModel(user));
            }
            TotalCount = usersList.TotalCount;
            Page = page;
            Size = size;

            CanBack = Page > 0;
            CanForward = (Page + 1) * Size < TotalCount;
        }
    }
}
