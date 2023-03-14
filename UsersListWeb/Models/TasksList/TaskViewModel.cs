using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using UsersList.Logic.Models.TasksList;
using UsersList.Logic.Models.UsersList;

namespace UsersListWeb.Models.TasksList
{
    public class TaskViewModel
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }

        public string Subject { get; set; }

        public string Description { get; set; }

        public int IdUser { get; set; }

        public TaskViewModel(TaskDTO user)
        {
            Id = user.Id;
            Subject = user.Subject;
            Description = user.Description;
            IdUser = user.IdUser;
        }
    }
}
