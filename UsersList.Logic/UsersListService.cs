using System;
using UsersListLogic.Models.UsersList;
using UsersListLogic.Models;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using UsersList.DAL.Repositories.Abstact;
using UsersList.DAL.Repositories;
using UsersList.Logic.Models.UsersList;

namespace UsersListLogic
{
    public class UsersListService
    {
        private IUserRepostitory _usersRepository;
        
        public UsersListService(IUserRepostitory usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public UsersListDTO Get(int skip, int take)
        {
            var result = new UsersListDTO
            {
                Skip = skip,
                Take = take
            };
            var count = _usersRepository.GetCount(x => true);
            result.TotalCount = count;

            if (skip > count)
            {
                result.Users = new List<UserDTO>();
                return result;
            }

            result.Users = _usersRepository
                .Get(x => true, skip, take)
                .Select(x => new UserDTO()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    IdTask =x.IdTask
                }).ToList();

            return result;
        }
    }
}
