using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ReactProject.Models;

namespace ReactProject.Infrastructure
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private StudentDbContext context { get; set; }
        private DbSet<T> _dbSet { get; set; }
        public BaseRepository(StudentDbContext context)
        {
            this.context = context;
            this._dbSet = context.Set<T>();
        }
        public List<T> GetAll()
        {
            return this._dbSet.ToList();
        }
        public T Get(Expression<Func<T, bool>> where)
        {
            return this._dbSet.Where(where).FirstOrDefault();
        }
        public List<T> GetMany(Expression<Func<T, bool>> where)
        {
            return this._dbSet.Where(where).ToList();
        }
        public IQueryable<T> Where(Expression<Func<T, bool>> where)
        {
            return this._dbSet.Where(where);
        }
        public IQueryable<T> QueryAll()
        {
            return this._dbSet;
        }
        public void Add(T model)
        {
            this._dbSet.Add(model);
            this.context.Entry(model).State = EntityState.Added;
        }
        public void Update(T model)
        {
            this._dbSet.Update(model);
            this.context.Entry(model).State = EntityState.Modified;
        }
        public void Delete(T model)
        {
            this._dbSet.Remove(model);
        }
        public void Commit()
        {
            this.context.SaveChanges();
        }
        public StudentDbContext GetDBContext()
        {
            return this.context;
        }
    }
}