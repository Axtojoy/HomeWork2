using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersList.Domain.Models.Users;

namespace UsersList.DAL.Mock.Data
{
    public class UserMockData
    {
        private List<Users> _users;
        private TasksMockData _tasksMockData;

        public UserMockData()
        {
            _users = new List<Users>();
            List<string> firstName = new List<string>() { "Вася", "Курага", "Кирилл", "Геннадий", "Василий", "Горя", "Анатолий", "Дмитрий" };
            List<string> lastName = new List<string>() { "Маслов", "Ушколов", "Урусов", "Крутов", " Кузахметов", "Лаврешин", "Земсков" };
            List<string> email = new List<string>() { "dsad@yandex.ru", "blavbl@mail.ru", "gasfsafda@mail.ru", "ihdasdasdh@mail.ru", "dasdas@gmail.com" };
            Random rnd = new Random();
            for (int i = 1; i <= 76; i++)
            {
                int randFirstName = rnd.Next(firstName.Count);
                int randLastName = rnd.Next(lastName.Count);
                int randEmail = rnd.Next(email.Count);
                _users.Add(new Users()
                {
                    Id = i,
                    FirstName = firstName[randFirstName],
                    LastName = lastName[randLastName],
                    Email = email[randEmail],
                    TaskId = i

                });
            }

        }
        public List<Users> Users => _users;
    }
}
