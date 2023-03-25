using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T = UsersList.Domain.Models.Users;

namespace UsersList.Domain.Repositories.Abstact
{
    public interface IUserRepostitory: IRepostitory<T.Users>
    {
        ICollection<T.Users> Get(string search, int skip, int take);
    }
}
