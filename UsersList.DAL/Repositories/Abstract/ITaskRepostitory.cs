using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T= UsersList.DAL.Domain.Tasks;
namespace UsersList.DAL.Repositories.Abstact
{
    public interface ITaskRepostitory: IRepostitory<T.Tasks>
    {
        
    }
}
