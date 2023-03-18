using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersList.DAL.Domain.Tasks;
using UsersList.DAL.Domain.Users;
using UsersList.DAL.Mock.Data;
using UsersList.DAL.Repositories.Abstact;

namespace UsersList.DAL.Mock
{
    public class TasksMockRepository : ITaskRepostitory, IRepostitory<Tasks>
    {
        private TasksMockData _taskMockData;

        public TasksMockRepository(TasksMockData taskMockData)
        {
            _taskMockData = taskMockData;
        }

        public Tasks Create(Tasks item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var user = _taskMockData.Tasks.FirstOrDefault(x => x.Id == id);
            _taskMockData.Tasks.Remove(user);
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

        public ICollection<Tasks> Get(string search, int page, int take)
        {
            throw new NotImplementedException();
        }

        public int GetCount(Func<Tasks, bool> where)
        {
            return _taskMockData
                .Tasks
                .Where(where)
                .Count();
        }


        public int GetCount()
        {
            throw new NotImplementedException();
        }

        public Tasks Save(Tasks item)
        {
            if (item.Id <= 0)
            {
                item.Id = _taskMockData.Tasks.Last().Id + 1;
                item.UserId = _taskMockData.Tasks.Last().UserId + 1;
                _taskMockData.Tasks.Add(item);
                return item;
            }

            var task = _taskMockData.Tasks.SingleOrDefault(x => x.Id == item.Id);
            task.Subject = item.Subject;
            task.Description = item.Description;
            task.UserId = item.UserId;

            return task;
        }

        public void Update(Tasks item)
        {
            throw new NotImplementedException();
        }

        Tasks IRepostitory<Tasks>.Update(Tasks item)
        {
            throw new NotImplementedException();
        }
    }
}
