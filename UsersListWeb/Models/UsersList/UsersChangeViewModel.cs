using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace UsersListWeb.Models.UsersList
{
    public class UsersChangeViewModel
    {
        [FromRoute(Name = "Id")]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int TaskId { get; set; }

    }
}
