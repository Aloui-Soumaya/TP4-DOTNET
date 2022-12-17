using System.Linq.Expressions;

namespace TP4_Soumaya.Data
{
    public interface IStudentRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id); IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        bool Add(TEntity entity);
        bool Remove(TEntity entity);
        IEnumerable<String> GetCourses();
    }
}
