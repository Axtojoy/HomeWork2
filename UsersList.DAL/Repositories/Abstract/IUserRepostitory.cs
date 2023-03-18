using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T = UsersList.DAL.Domain.Users;

namespace UsersList.DAL.Repositories.Abstact
{
    public interface IUserRepostitory: IRepostitory<T.Users>
    {
        
    }
}
