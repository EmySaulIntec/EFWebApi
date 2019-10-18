using MyDbTest.Models;
using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace MyDbTest.Repositories
{
    public class Repository<T> : IRepository<T>  where T : class
    {

        RestaurantDbContext Context;

        public Repository()
        {
            Context = new RestaurantDbContext();
        }

        public Repository(RestaurantDbContext context)
        {
            Context = context;
        }

        public T Single(Expression<Func<T, bool>> expression) 
        {
            return All().FirstOrDefault(expression);
        }

        public IQueryable<T> All() 
        {
            return Context.Set<T>().AsQueryable();
        }

        public virtual IQueryable<T> Filter(Expression<Func<T, bool>> predicate) 
        {
            return Context.Set<T>().Where<T>(predicate).AsQueryable<T>();
        }

        public virtual IQueryable<T> Filter(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50) 
        {
            int skipCount = index * size;
            var _resetSet = filter != null ? Context.Set<T>().Where<T>(filter).AsQueryable() : Context.Set<T>().AsQueryable();
            _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
            total = _resetSet.Count();
            return _resetSet.AsQueryable();
        }

        public virtual T Create(T TObject) 
        {

            var newEntry = Context.Set<T>().Add(TObject);
            Context.SaveChanges();
            return newEntry;
        }

        public virtual int Delete(T TObject) 
        {
            Context.Set<T>().Remove(TObject);
            return Context.SaveChanges();
        }

        public virtual int Update(T TObject) 
        {
            try
            {
                var entry = Context.Entry(TObject);
                Context.Set<T>().Attach(TObject);
                entry.State = EntityState.Modified;
                return Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual int Delete(Expression<Func<T, bool>> predicate) 
        {
            var objects = Filter(predicate);
            foreach (var obj in objects)
                Context.Set<T>().Remove(obj);
            return Context.SaveChanges();
        }

        public bool Contains(Expression<Func<T, bool>> predicate) 
        {
            return Context.Set<T>().Count<T>(predicate) > 0;
        }

        public virtual T Find(params object[] keys)
        {
            return (T)Context.Set<T>().Find(keys);
        }

        public virtual T Find(Expression<Func<T, bool>> predicate) 
        {
            return Context.Set<T>().FirstOrDefault<T>(predicate);
        }


        public virtual void ExecuteProcedure(String procedureCommand, params SqlParameter[] sqlParams)
        {
            Context.Database.ExecuteSqlCommand(procedureCommand, sqlParams);

        }

        public virtual void SaveChanges()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            if (Context != null)
                Context.Dispose();
        }
    }
}
