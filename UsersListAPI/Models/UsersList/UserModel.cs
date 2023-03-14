using Microsoft.AspNetCore.Mvc;
using UsersList.Logic.Models.UsersList;

namespace UsersListWeb.Models.UsersList
{
    public class UserModel
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int IdTask { get; set; }


        public UserModel(UserDTO user) {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            IdTask = user.IdTask;
        }
    }

}
