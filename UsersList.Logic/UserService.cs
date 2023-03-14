using System;
using System.Collections.Generic;
using System.Text;
using UsersList.DAL.Domain.Users;
using UsersList.DAL.Repositories.Abstact;
using UsersList.Logic.Models.UsersList;
using UsersListLogic.Models;
using UsersListLogic.Models.UsersList;

namespace UsersListLogic
{
    public class UserService
    {
        private IUserRepostitory _userRepository;
        public UserService(IUserRepostitory userRepository)
        {
            _userRepository = userRepository;
        }
        public UserDTO Get(int id) 
        {
            var user = _userRepository.Get(id);
            return new UserDTO()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                IdTask = user.IdTask,
                
            };
        }
        public int Create(UsersListCreateDTO listCreateDTO)
        {
            var newUserList = new Users()
            {
                FirstName = listCreateDTO.FirstName,
                LastName = listCreateDTO.LastName,
                Email = listCreateDTO.Email,
                //IdTask = listCreateDTO.IdTask
            };
            var users = _userRepository.Save(newUserList);
            return users.Id;
        }
        public object Update(UsersListChangeDTO userChange)
        {

            var newUserList = new Users()
            {
                Id = userChange.Id,
                FirstName = userChange.FirstName,
                LastName = userChange.LastName,
                Email = userChange.Email,
                IdTask = userChange.Id
                
            };
            var user = _userRepository.Save(newUserList);

            return user.Id;
        }
    }
}
