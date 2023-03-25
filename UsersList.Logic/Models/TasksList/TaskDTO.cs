using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace UsersList.Logic.Models.TasksList
{
    public class TaskDTO
    {
        public int Id { get; set; }

        public string Subject { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime DeadlineDate { get; set; }
    }
}
