using System;
using System.Collections.Generic;
using System.Text;

namespace UsersListLogic.Models.UsersList
{
    public class UsersListChangeDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int IdTask { get; set; }
    }
}
