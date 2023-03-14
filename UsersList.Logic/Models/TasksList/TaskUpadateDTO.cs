using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersList.Logic.Models.TasksList
{
    public class UserslistChangeDTO
    {
        public int Id { get; set; }

        public string Subject { get; set; }

        public string Description { get; set; }

        public int IdUser { get; set; }
    }
}
