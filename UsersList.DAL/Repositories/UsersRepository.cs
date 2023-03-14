using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersList.DAL.Domain.Users;
using UsersList.DAL.Repositories.Abstact;

namespace UsersList.DAL.Repositories
{
   public class UsersRepository: IUserRepostitory, IRepostitory<Users>
    {
        private UserMockData _userMockData;
        public UsersRepository(UserMockData userMockData) 
        {
            _userMockData = userMockData;
           
        }
        public Users Get(int id)
        {
            return _userMockData.Users.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Users> Get(Func<Users, bool> where)
        {
            return _userMockData.Users.Where(where).ToList();
        }

        public ICollection<Users> Get(Func<Users, bool> where, int skip, int take)
        {
            return _userMockData
                .Users
                .Where(where)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public int GetCount(Func<Users, bool> where)
        {
            return _userMockData
                .Users
                .Where(where)
                .Count();
        }

        public Users Save(Users item)
        {
            if (item.Id <= 0)
            {
                item.Id = _userMockData.Users.Last().Id + 1;
                item.IdTask = _userMockData.Users.Last().IdTask + 1;
                _userMockData.Users.Add(item);
                return item;
            }

            var user = _userMockData.Users.SingleOrDefault(x => x.Id == item.Id);
            user.FirstName = item.FirstName;
            user.LastName = item.LastName;
            user.Email = item.Email;
            user.IdTask = item.IdTask;
            return user;
        }
    }
}
