using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TP4_Soumaya.Models;

namespace TP4_Soumaya.Data
{
    
    public class StudentRepository : IStudentRepository<Student>
    {
        private readonly UniversityContext universityContext;
        public StudentRepository(UniversityContext universityContext)
        {
            this.universityContext = universityContext;
        }
        public bool Add(Student entity)
        {
            try
            {
                universityContext.Set<Student>().Add(entity);
                universityContext.SaveChanges();

                return true;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public IEnumerable<Student> Find(Expression<Func<Student, bool>> predicate)
        {
            try
            {
                return universityContext.Set<Student>().Where(predicate);

            }
            catch (Exception e)
            {

                throw e;
            }
        }
        

        public IEnumerable<Student> GetAll()
        {
            try
            {
                return universityContext.Set<Student>().ToList();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public Student Get(int id)
        {
            try
            {

                return universityContext.Set<Student>().Find(id);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public IEnumerable<String> GetCourses()
        {
            return universityContext
                .Student.Select(s => s.course).Distinct().ToList();
        }

        public bool Remove(Student entity)
        {
            try
            {
                universityContext.Set<Student>().Remove(entity);
                universityContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

    }
}
