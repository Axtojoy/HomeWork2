using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersList.Domain.Models.Tasks;
using UsersList.Domain.Models.Users;
using UsersList.Domain.Repositories.Abstact;

namespace UsersList.DAL.EF.Repositories
{
    public class TaskEFPostgreeRepository: ITaskRepostitory, IRepostitory<Tasks>
    {
        private readonly PostgreeContext _context;

        public TaskEFPostgreeRepository(PostgreeContext context)
        {
            _context = context;
        }

        public Tasks Create(Tasks item)
        {
            item.UserId = 1;
            _context.Tasks.Add(item);
            _context.SaveChanges();
            return item;
        }

        public void Delete(int id)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == id);

            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }

        public ICollection<Tasks> Get(string search, int skip, int take)
        {
            var tasks = _context.Tasks
              .Where(x => string.IsNullOrEmpty(search) || x.Subject.Contains(search) || x.Description.Contains(search))
              .Skip(skip)
              .Take(take)
              .ToList();

            return tasks;
        }

        public Tasks Get(int id)
        {
            return _context.Tasks.FirstOrDefault(x => x.Id == id);
        }

        public int GetCount()
        {
            return _context.Tasks.Count();
        }

        public void Update(Tasks item)
        {
            _context.Tasks.Update(item);
            _context.SaveChanges();
        }
    }
}
