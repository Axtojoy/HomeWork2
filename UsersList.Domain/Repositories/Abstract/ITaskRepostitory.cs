using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T= UsersList.Domain.Models.Tasks;
namespace UsersList.Domain.Repositories.Abstact
{
    public interface ITaskRepostitory: IRepostitory<T.Tasks>
    {
        ICollection<T.Tasks> Get(string search, int skip, int take);
    }
}
