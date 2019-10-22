using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using shared_classes.Models;
using shared_classes.Data;


namespace shared_classes.Data
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T>
        where T : class, IEntityBase, new()
    {
        private BlogDbContext _context;
        public EntityBaseRepository(BlogDbContext context)
        {
            _context = context;
        }
        public T GetById(int id)
        {
            return _context.Set<T>().FirstOrDefault(b => b.Id==id);
        }
        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable();
        }
        public IEnumerable<T> GetByExpr(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }
        public void Add(T entity)
        {
            EntityEntry dbEntry = _context.Entry<T>(entity);
            _context.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            EntityEntry dbEntry = _context.Entry<T>(entity);
            dbEntry.State = EntityState.Modified;
        }
        public void Delete(T entity)
        {
            EntityEntry dbEntry = _context.Entry<T>(entity);
            dbEntry.State = EntityState.Deleted;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}