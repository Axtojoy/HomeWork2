﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersList.Logic.Models.TasksList
{
    public class TaskListDTO
    {
        public List<TaskDTO> Tasks { get; set; }

        public int TotalCount { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }

    }
}
