using MyDbTest.Models;
using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace MyDbTest.Repositories
{
    public class Repository<T, Context> : IRepository<T, Context>  where T : class where Context : DbContext
    {
        Context MyContext;

        public Repository()
        {
            MyContext = Activator.CreateInstance<Context>();
        }

        public Repository(Context context)
        {
            MyContext = context;
        }

        public T Single(Expression<Func<T, bool>> expression) 
        {
            return All().FirstOrDefault(expression);
        }

        public IQueryable<T> All() 
        {
            return MyContext.Set<T>().AsQueryable();
        }

        public virtual IQueryable<T> Filter(Expression<Func<T, bool>> predicate) 
        {
            return MyContext.Set<T>().Where<T>(predicate).AsQueryable<T>();
        }

        public virtual IQueryable<T> Filter(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50) 
        {
            int skipCount = index * size;
            var _resetSet = filter != null ? MyContext.Set<T>().Where<T>(filter).AsQueryable() : MyContext.Set<T>().AsQueryable();
            _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
            total = _resetSet.Count();
            return _resetSet.AsQueryable();
        }

        public virtual T Create(T TObject) 
        {

            var newEntry = MyContext.Set<T>().Add(TObject);
            MyContext.SaveChanges();
            return newEntry;
        }

        public virtual int Delete(T TObject) 
        {
            MyContext.Set<T>().Remove(TObject);
            return MyContext.SaveChanges();
        }

        public virtual int Update(T TObject) 
        {
            try
            {
                var entry = MyContext.Entry(TObject);
                MyContext.Set<T>().Attach(TObject);
                entry.State = EntityState.Modified;
                return MyContext.SaveChanges();
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
                MyContext.Set<T>().Remove(obj);
            return MyContext.SaveChanges();
        }

        public bool Contains(Expression<Func<T, bool>> predicate) 
        {
            return MyContext.Set<T>().Count<T>(predicate) > 0;
        }

        public virtual T Find(params object[] keys)
        {
            return (T)MyContext.Set<T>().Find(keys);
        }

        public virtual T Find(Expression<Func<T, bool>> predicate) 
        {
            return MyContext.Set<T>().FirstOrDefault<T>(predicate);
        }


        public virtual void ExecuteProcedure(String procedureCommand, params SqlParameter[] sqlParams)
        {
            MyContext.Database.ExecuteSqlCommand(procedureCommand, sqlParams);

        }

        public virtual void SaveChanges()
        {
            MyContext.SaveChanges();
        }

        public void Dispose()
        {
            if (MyContext != null)
                MyContext.Dispose();
        }
    }
}
