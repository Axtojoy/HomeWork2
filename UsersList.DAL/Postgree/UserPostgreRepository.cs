﻿using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersList.Domain.Models.Tasks;
using UsersList.Domain.Models.Users;
using UsersList.Domain.Repositories;
using UsersList.Domain.Repositories.Abstact;

namespace UsersList.Domain.Postgree
{
    public class UserPostgreRepository : IUserRepostitory, IRepostitory<Users>
    {
        private readonly NpgsqlConnection _connection;
        public UserPostgreRepository(string connectionString) {
            _connection = new NpgsqlConnection(connectionString);
        }
        public Users Create(Users item)
        {
             _connection.Execute("INSERT INTO public.\"Users\" (\"FirstName\", \"LastName\", \"Email\")" +
                 "VALUES(@FirstName, @LastName, @Email)", new {FirstName = item.FirstName, LastName = item.LastName, Email = item.Email});
            return item;
        }

        public void Delete(int id)
        {
            _connection.Execute("Delete public.\"Users\" WHERE id = @id", new { Id = id });
        }

        public Users Get(int id)
        {
            var user = _connection.Query<Users>("SELECT * FROM public.\"Users\" WHERE Id = @id", new { Id = id }).FirstOrDefault();
            return user;
        }

        public ICollection<Users> Get(string search, int skip, int take)
        {
            var searchQuery = string.IsNullOrWhiteSpace(search) ? "" : $"WHERE \"Name\" ilike 'search%' or \"Surname\" ilike 'search%'";

            var users = _connection.Query<Users>($"SELECT * FROM public.\"Users\" {searchQuery} OFFSET {skip} LIMIT {take}").ToList();
            return users ?? new List<Users>();
        }

        public int GetCount()
        {
            var count = _connection.Query("SELECT * FROM public.\"Users\"").Count();
            return count;
        }
        public void Update(Users item)
        {
            _connection.Execute("UPDATE public.\"Users\" SET \"FirstName\" = @FirstName, \"LastName\"  = @LastName, \"Email\" = @Email WHERE Id = @Id", new { FirstName = item.FirstName, LastName = item.LastName, Email = item.Email });
            

        }
    }
}
