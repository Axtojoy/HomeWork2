using System;
using System.Collections.Generic;
using System.Text;
using UsersList.Domain.Repositories.Abstact;
using UsersListLogic.Models;
using UsersListLogic.Models.UsersList;
using UsersList.Logic.Models.TasksList;
using UsersList.Logic.Models.UsersList;

namespace UsersListLogic
{
    public class TaskListService
    {
        private IUserRepostitory _userRepository;
        private ITaskRepostitory _taskRepository;
        public TaskListService(IUserRepostitory userRepository, ITaskRepostitory taskRepository)
        {
            _userRepository = userRepository;
            _taskRepository = taskRepository;
        }
        public TaskListDTO Get(int skip, int take)
        {
            var result = new TaskListDTO
            {
                Skip = skip,
                Take = take
            };

            var count = _taskRepository.GetCount();
            result.TotalCount = count;

            if (skip > count)
            {
                result.Tasks = new List<TaskDTO>();
                return result;
            }

            result.Tasks = _taskRepository
                .Get(string.Empty, skip, take)
                .Select(x => new TaskDTO()
                {
                    Id = x.Id,
                    Subject = x.Subject,
                    UserId = (int)x.UserId,
                    Description = x.Description,
                    CreatedDate = x.CreatedDate,
                    DeadlineDate = x.DeadlineDate
                    
                }).ToList();

            return result;
        }

    }
}
