using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersList.Domain.Models.Users;
using UsersList.DAL.Mock.Data;
using UsersList.Domain.Repositories.Abstact;

namespace UsersList.Domain.Mock
{
    public class UsersMockRepository : IUserRepostitory, IRepostitory<Users>
    {
        private UserMockData _userMockData;
        public UsersMockRepository(UserMockData userMockData)
        {
            _userMockData = userMockData;

        }

        public Users Create(Users item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var user = _userMockData.Users.FirstOrDefault(x => x.Id == id);
            _userMockData.Users.Remove(user);
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

        public ICollection<Users> Get(string search, int page, int take)
        {
            throw new NotImplementedException();
        }

        public int GetCount(Func<Users, bool> where)
        {
            return _userMockData
                .Users
                .Where(where)
                .Count();
        }


        public int GetCount()
        {
            throw new NotImplementedException();
        }

        public Users Save(Users item)
        {
            if (item.Id <= 0)
            {
                item.Id = _userMockData.Users.Last().Id + 1;
                item.TaskId = _userMockData.Users.Last().TaskId + 1;
                _userMockData.Users.Add(item);
                return item;
            }

            var user = _userMockData.Users.SingleOrDefault(x => x.Id == item.Id);
            user.FirstName = item.FirstName;
            user.LastName = item.LastName;
            user.Email = item.Email;
            user.TaskId = item.TaskId;
            return user;
        }

        public void Update(Users item)
        {
            throw new NotImplementedException();
        }

    }
}
