using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace UsersListWeb.Models.UsersList
{
    public class UsersListChangeModel
    {
        [FromRoute(Name = "Id")]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int IdTask { get; set; }

    }
}
