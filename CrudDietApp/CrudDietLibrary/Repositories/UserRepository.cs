using CrudDietLibrary.Data;
using CrudDietLibrary.Interfaces;
using CrudDietLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CrudDietLibrary.Repositories
{
    public class UserRepository : Repository<User, Recipe>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public IEnumerable<User> FindAll(Expression<Func<User, List<Recipe>>> expression)
        {
            return Repos.Set<User>().Include<User, List<Recipe>>(expression).AsNoTracking();
        }

        public IEnumerable<User> FindByCondition(Expression<Func<User, bool>> expression, Expression<Func<User, List<Recipe>>> expression2)
        {
            return Repos.Set<User>().Include(expression2).Where(expression).AsNoTracking();
        }
    }
}
