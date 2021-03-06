using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudDietLibrary.Interfaces
{
    //To access dbtables and save changes
    public interface IRepositoryWrapper
    {
        IUserRepository Users { get; }
        IRecipeRepository Recipes { get; }
        void Save();
    }
}
