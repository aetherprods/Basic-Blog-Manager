using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using shared_classes.Models;
using System.Threading.Tasks;


namespace shared_classes.Data
{
    public class EntityBaseMemoryRepository<T> : IEntityBaseRepository<T>
        where T : class, IEntityBase, new()
    {
        private ICollection<T> _collection;
        public EntityBaseMemoryRepository(ICollection<T> collection)
        {
            _collection = collection;
        }
        public T GetById(int id)
        {
            return _collection.First(b => b.Id==id);
        }
        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            Func<T, bool> bul = predicate.Compile();

            return (from T item in _collection
                where bul(item)
                select item).FirstOrDefault();
        }
        public IEnumerable<T> GetAll()
        {
            return _collection;
        }
        public IEnumerable<T> GetByExpr(Expression<Func<T, bool>> predicate)
        {
            Func<T, bool> bul = predicate.Compile();
            
            return from T item in _collection
                where bul(item)
                select item;
        }
        public void Add(T entity)
        {
            _collection.Add(entity);
        }
        public void Update(T entity)
        {
            Delete(entity);
            _collection.Add(entity);
        }
        public void Delete(T entity)
        {
            _collection.Remove((from item in _collection where item.Id==entity.Id select item).FirstOrDefault());
        }
        public void Commit()
        {
            _collection = _collection;
        }
    }
}