using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersList.DAL.Domain.Tasks;
using UsersList.DAL.Domain.Users;
using UsersList.DAL.Mock.Data;
using UsersList.DAL.Repositories.Abstact;

namespace UsersList.DAL.Postgree
{
    public class TaskPostgreRepository : ITaskRepostitory, IRepostitory<Tasks>
    {
        private readonly NpgsqlConnection _connection;
        public TaskPostgreRepository(string connectionString) {

            _connection = new NpgsqlConnection(connectionString);
        }

        public Tasks Create(Tasks item)
        {
            
            _connection.Execute("INSERT INTO public.\"Tasks\" (\"Description\", \"Subject\")" +
                "VALUES(@Description, @Subject)", new { Description = item.Description, Subject = item.Subject });
            return item;

            
        }

        public void Delete(int id)
        {
            _connection.Execute("Delete public.\"Tasks\" WHERE id = @id", new { Id = id });
        }

        public Tasks Get(int id)
        {
            var task = _connection.Query<Tasks>("SELECT * FROM public.\"Tasks\" WHERE Id = @id", new {Id = id}).FirstOrDefault();
            return task;
        }

        public int GetCount()
        {
            var count = _connection.Query("SELECT * FROM public.\"Tasks\"").Count();
            return count;
        }

        public Tasks Update(Tasks item)
        {
            _connection.Execute("UPDATE public.\"Tasks\" SET \"Description\" = @Description,  \"Subject\" = @Subject WHERE Id = @Id", new {Description = item.Description, Subject = item.Subject});
            return item;

        }
    }
}
