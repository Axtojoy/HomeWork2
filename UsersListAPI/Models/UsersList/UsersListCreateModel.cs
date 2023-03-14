using Microsoft.AspNetCore.Mvc;

namespace UsersListWeb.Models.UsersList
{
    public class UsersListCreateModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

    }
}
