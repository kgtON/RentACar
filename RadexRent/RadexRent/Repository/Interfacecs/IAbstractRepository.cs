using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace RadexRent.Repository.Interfaces
{
    public interface IAbstractRepository<T> where T : class
    {
        void Create(T entity);
        void Delete(T entity);
        void Edit(T entity);
        List<T> GetWhere(Expression<Func<T, bool>> expression);
        List<T> GetWhereWithIncludes(Expression<Func<T, bool>> expressionWhere, params Expression<Func<T, object>>[] includes);
    }
}