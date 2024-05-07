using System.Linq.Expressions;
using ReactProject.Models;

namespace ReactProject.Infrastructure
{

    public interface IBaseRepository<T> where T : class
    {
        List<T> GetAll();
        List<T> GetMany(Expression<Func<T, bool>> where);
        IQueryable<T> Where(Expression<Func<T, bool>> where);
        T Get(Expression<Func<T, bool>> where);
        IQueryable<T> QueryAll();
        void Add(T model);
        void Update(T model);
        void Delete(T model);
        void Commit();
        StudentDbContext GetDBContext();
    }
}