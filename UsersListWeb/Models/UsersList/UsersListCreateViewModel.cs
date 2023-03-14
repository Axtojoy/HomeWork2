using Microsoft.AspNetCore.Mvc;

namespace UsersListWeb.Models.UsersList
{
    public class UsersListCreateViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        //public int IdTask { get; set; }
    }
}
