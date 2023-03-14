using System;
using System.Collections.Generic;
using System.Text;
using UsersList.Logic.Models.UsersList;

namespace UsersListLogic.Models.UsersList
{
    public class UsersListDTO
    {
        public List<UserDTO> Users { get; set; }
        public int TotalCount { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }

    }
}
