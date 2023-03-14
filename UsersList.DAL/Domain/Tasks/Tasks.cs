using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersList.DAL.Domain.Tasks
{
    public class Tasks
    {
        public int Id { get; set; }

        public string Subject { get; set; }

        public string Description { get; set; }

        public int IdUser { get; set; }
    }
}
