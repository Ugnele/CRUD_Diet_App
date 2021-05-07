﻿using CrudDietLibrary.Data;
using CrudDietLibrary.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CrudDietLibrary.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected ApplicationDbContext Repos { get; set; }
        public Repository(ApplicationDbContext reposContext)
        {
            Repos = reposContext;
        }

        public T Create(T entity)
        {
            return Repos.Set<T>().Add(entity).Entity;

        }

        public IEnumerable<T> FindAll()
        {
            return Repos.Set<T>().AsNoTracking();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return Repos.Set<T>().Where(expression).AsNoTracking();
        }

        public T Update(T entity)
        {
            return Repos.Set<T>().Update(entity).Entity;
        }

        public void Delete(T entity)
        {
            Repos.Set<T>().Remove(entity);
        }
    }
}
