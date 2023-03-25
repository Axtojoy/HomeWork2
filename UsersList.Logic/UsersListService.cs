using System;
using UsersListLogic.Models.UsersList;
using UsersListLogic.Models;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using UsersList.Domain.Repositories.Abstact;
using UsersList.Domain.Repositories;
using UsersList.Logic.Models.UsersList;
using UsersList.Domain.Postgree;

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
            var count = _usersRepository.GetCount();
            result.TotalCount = count;

            if (skip > count)
            {
                result.Users = new List<UserDTO>();
                return result;
            }

            result.Users = _usersRepository
                .Get(string.Empty, skip, take)
                .Select(x => new UserDTO()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    IdTask = x.TaskId
                }).ToList();

            return result;
        }
    }
}
