using CrudDietLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudDietLibrary.Interfaces
{
    public interface IUserRepository : IRepository<User, List<Recipe>>
    {
        
    }
}
