using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UsersList.Domain.Models.Tasks;
using UsersList.Domain.Models.Users;

namespace UsersList.DAL.EF
{
    public class PostgreeContext: DbContext
    {
        public PostgreeContext(DbContextOptions<PostgreeContext> options)
           : base(options)
        {
        }


        public DbSet<Users> Users => Set<Users>();
        public DbSet<Tasks> Tasks => Set<Tasks>();
    }
}