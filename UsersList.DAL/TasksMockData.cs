﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersList.DAL.Domain.Tasks;

namespace UsersList.DAL
{
    public class TasksMockData
    {
        private UserMockData _userMockData;

        private List<Tasks> _tasks;

        public TasksMockData(UserMockData userMockData)
        {
            _userMockData = userMockData;
            _tasks = new List<Tasks>();
            Random rnd = new Random();
            for(int i = 1; i <= 76; i++)
            {
                _tasks.Add(new Tasks()
                {
                    Id = i,
                    Subject = $"Task {i}",
                    IdUser = i, 
                    Description = $"Description of task {i}"
                    
                });
            }
        }
        public List<Tasks> Tasks => _tasks;
    }
}
