using CrudDietLibrary.Data;
using CrudDietLibrary.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudDietLibrary.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        readonly ApplicationDbContext _repoContext;
        public RepositoryWrapper(ApplicationDbContext repoContext)
        {
            _repoContext = repoContext;
        }
        IUserRepository _users;

        IRecipeRepository _recipes;

        public IUserRepository Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new UserRepository(_repoContext);
                }
                return _users;
            }
        }
        public IRecipeRepository Recipes
        {
            get
            {
                if (_recipes == null)
                {
                    _recipes = new RecipeRepository(_repoContext);
                }
                return _recipes;
            }
        }
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
