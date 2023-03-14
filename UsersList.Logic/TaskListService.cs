using System;
using System.Collections.Generic;
using System.Text;
using UsersList.DAL.Repositories.Abstact;
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

            var count = _taskRepository.GetCount(x => true);
            result.TotalCount = count;

            if (skip > count)
            {
                result.Tasks = new List<TaskDTO>();
                return result;
            }

            result.Tasks = _taskRepository
                .Get(x => true, skip, take)
                .Select(x => new TaskDTO()
                {
                    Id = x.Id,
                    Subject = x.Subject,
                    IdUser = x.IdUser,
                    Description = x.Description
                }).ToList();

            return result;
        }

    }
}
