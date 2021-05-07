using CrudDietLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CrudDietLibrary.Interfaces
{
    public interface IRepository<T, U>
    {
        T Create(T entity);
        IEnumerable<T> FindAll();
        IEnumerable<T> FindAll(Expression<Func<T, U>> expression);
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression, Expression<Func<T, U>> expression2);
        T Update(T entity);
        void Delete(T entity);
    }
}
