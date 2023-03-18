using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;
using UsersList.DAL.Domain.Tasks;
using UsersList.DAL.Repositories.Abstact;
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
                IdUser = task.UserId,
                Description = task.Description
            };
        }
        public int Create(TaskCreateDTO taskCreate)
        {
            var newTask = new Tasks()
            {
                Description = taskCreate.Description,
                Subject = taskCreate.Subject,
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
                UserId = taskUpdate.Id,
                Description = taskUpdate.Description,
                Subject = taskUpdate.Subject
            };

            var task = _taskRepository.Update(newTask);

            return task.Id;

        }

    }
}
