using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersList.Domain.Models.Users;
using UsersList.Domain.Repositories.Abstact;

namespace UsersList.DAL.EF.Repositories
{
    public class UserEFPostgreeRepository : IUserRepostitory, IRepostitory<Users>
    {
        private readonly PostgreeContext _context;

        public UserEFPostgreeRepository(PostgreeContext context)
        {
            _context = context;
        }
        public Users Create(Users item)
        {
            item.TaskId = 1;
            _context.Users.Add(item);
            _context.SaveChanges();
            return item;
        }

        public void Delete(int id)
        {
            var task = _context.Users.FirstOrDefault(t => t.Id == id);

            if (task != null)
            {
                _context.Users.Remove(task);
                _context.SaveChanges();
            }
        }

        public Users Get(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Users> Get(string search, int skip, int take)
        {
            IQueryable<Users> query = _context.Users;
            if (!string.IsNullOrEmpty(search))
                query = query.Where(x => x.FirstName.StartsWith(search) || x.LastName.StartsWith(search));

            var users = query
                .Skip(skip)
                .Take(take)
                .ToList();

            return users;
        }

        public int GetCount()
        {
            return _context.Users.Count();
        }

        public void Update(Users item)
        {
            _context.Users.Update(item);
            _context.SaveChanges();
        }
    }
}
