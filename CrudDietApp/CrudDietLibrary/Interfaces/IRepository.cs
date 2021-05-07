﻿using CrudDietLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CrudDietLibrary.Interfaces
{
    public interface IRepository<T>
    {
        T Create(T entity);
        IEnumerable<T> FindAll();
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
        T Update(T entity);
        void Delete(T entity);
    }
}
