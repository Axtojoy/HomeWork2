using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using UsersList.Logic.Models.TasksList;
using UsersList.Logic.Models.UsersList;

namespace UsersListWeb.Models.TasksList
{
    public class TaskModel
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }

        public string Subject { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }

        public TaskModel(TaskDTO user)
        {
            Id = user.Id;
            Subject = user.Subject;
            Description = user.Description;
            UserId = user.UserId;
        }
    }
}
