using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersList.Domain.Models.Tasks;
using UsersList.Domain.Models.Users;
using UsersList.DAL.Mock.Data;
using UsersList.Domain.Repositories.Abstact;

namespace UsersList.Domain.Postgree
{
    public class TaskPostgreRepository : ITaskRepostitory, IRepostitory<Tasks>
    {
        private readonly NpgsqlConnection _connection;
        public TaskPostgreRepository(string connectionString) {

            _connection = new NpgsqlConnection(connectionString);
        }

        public Tasks Create(Tasks item)
        {
            
            _connection.Execute("INSERT INTO public.\"Tasks\" (\"Description\", \"Subject\", \"DeadlineDate\", \"CreatedDate\", \"UserId\")" +
                "VALUES(@Description, @Subject, @DeadlineDate, @CreatedDate, @UserId)", new { Description = item.Description, Subject = item.Subject, DeadlineDate = item.DeadlineDate, CreatedDate = item.CreatedDate, UserId = item.UserId });
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

        public ICollection<Tasks> Get(string search, int skip, int take)
        {
            var searchQuery = string.IsNullOrWhiteSpace(search) ? "" : $"WHERE \"Subject\" ilike '%search%' or \"Description\" ilike '%search%'";

            var tasks = _connection.Query<Tasks>($"SELECT * FROM public.\"Tasks\" {searchQuery} OFFSET {skip} LIMIT {take}").ToList();
            return tasks ?? new List<Tasks>();
        }

        public int GetCount()
        {
            var count = _connection.Query("SELECT * FROM public.\"Tasks\"").Count();
            return count;
        }

        public void Update(Tasks item)
        {
            _connection.Execute("UPDATE public.\"Tasks\" SET \"Description\" = @Description,  \"Subject\" = @Subject WHERE Id = @Id", new {Description = item.Description, Subject = item.Subject});
            

        }
    }
}
