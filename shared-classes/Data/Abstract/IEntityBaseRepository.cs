using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using shared_classes.Models;

namespace shared_classes.Data
{
    public interface IEntityBaseRepository<T>
        where T : class, IEntityBase, new()
    {
        T GetById(int id);
        T GetSingle(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetByExpr(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Commit();
    }
}
