using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace UsersListWeb.Models.TasksList
{
    public class TaskChangeViewModel
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }

        public string Subject { get; set; }

        public string Description { get; set; }

        public int IdUser { get; set; }
    }
}
