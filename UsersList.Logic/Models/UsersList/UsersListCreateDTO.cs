﻿using System;
using System.Collections.Generic;
using System.Text;
using UsersList.DAL.Domain.Users;

namespace UsersListLogic.Models.UsersList
{
    public class UsersListCreateDTO
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        //public int IdTask { get; set; }

    }
}
