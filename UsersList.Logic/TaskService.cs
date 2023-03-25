using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;
using UsersList.Domain.Models.Tasks;
using UsersList.Domain.Repositories.Abstact;
using UsersList.Logic.Models.TasksList;
using UsersList.Logic.Models.UsersList;
using UsersListLogic.Models;
using UsersListLogic.Models.UsersList;

namespace UsersListLogic
{
    public class TaskService
    {
        private IUserRepostitory _userRepository;
        private ITaskRepostitory _taskRepository;
        public TaskService(IUserRepostitory userRepository, ITaskRepostitory taskRepository)
        {
            _userRepository = userRepository;
            _taskRepository = taskRepository;
        }
        public TaskDTO Get(int id)
        {
            var task = _taskRepository.Get(id);
            return new TaskDTO()
            {
                Id = task.Id,
                Subject = task.Subject,
                UserId = (int)task.UserId,
                Description = task.Description,
                CreatedDate = task.CreatedDate,
                DeadlineDate = task.DeadlineDate
            };
        }
        public int Create(TaskCreateDTO taskCreate)
        {
            var newTask = new Tasks()
            {
                Description = taskCreate.Description,
                Subject = taskCreate.Subject,
                CreatedDate = taskCreate.CreatedDate,
                DeadlineDate = taskCreate.DeadlineDate
                //IdUser = taskCreate.IdUser
            };

            var task = _taskRepository.Create(newTask);

            return task.Id;
        }
        public object Update(UserslistChangeDTO taskUpdate)
        {
            var newTask = new Tasks()
            {
                Id = taskUpdate.Id,
                UserId = taskUpdate.IdUser,
                Description = taskUpdate.Description,
                Subject = taskUpdate.Subject, 
                CreatedDate = taskUpdate.CreatedDate,
                DeadlineDate = taskUpdate.DeadlineDate

            };

             _taskRepository.Update(newTask);

            return taskUpdate;

        }

    }
}
