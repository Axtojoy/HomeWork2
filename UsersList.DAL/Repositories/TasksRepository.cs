using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersList.DAL.Domain.Tasks;
using UsersList.DAL.Domain.Users;
using UsersList.DAL.Repositories.Abstact;

namespace UsersList.DAL.Repositories
{
    public class TasksRepository: ITaskRepostitory, IRepostitory<Tasks>
    {
        private TasksMockData _taskMockData;

        public TasksRepository(TasksMockData taskMockData) { 
            _taskMockData = taskMockData;
        }

        public Tasks Get(int id)
        {
            return _taskMockData.Tasks.FirstOrDefault(x => x.Id == id);
        }
        public ICollection<Tasks> Get(Func<Tasks, bool> where)
        {
            return _taskMockData
                .Tasks
                .Where(where)
                .ToList();
        }

        public ICollection<Tasks> Get(Func<Tasks, bool> where, int skip, int take)
        {
            return _taskMockData
                .Tasks
                .Where(where)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public int GetCount(Func<Tasks, bool> where)
        {
            return _taskMockData
                .Tasks
                .Where(where)
                .Count();
        }

        public Tasks Save(Tasks item)
        {
            if (item.Id <= 0)
            {
                item.Id = _taskMockData.Tasks.Last().Id + 1;
                item.IdUser = _taskMockData.Tasks.Last().IdUser + 1;
                _taskMockData.Tasks.Add(item);
                return item;
            }

            var task = _taskMockData.Tasks.SingleOrDefault(x => x.Id == item.Id);
            task.Subject = item.Subject;
            task.Description = item.Description;
            task.IdUser = item.IdUser;

            return task;
        }
    }
}
