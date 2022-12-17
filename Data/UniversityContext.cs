using Microsoft.EntityFrameworkCore;
using TP4_Soumaya.Models;

namespace TP4_Soumaya.Data
{
    public class UniversityContext : DbContext
    {
        public DbSet<Student> Student { get; set; }
        static private UniversityContext universityContextInstance = null;
        static public int nb_instance = 0;
        private UniversityContext(DbContextOptions o) : base(o)
        {
            nb_instance++;
        }
        static public UniversityContext Instantiate_UniversityContext()
        {
            if (universityContextInstance == null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<UniversityContext>();
                optionsBuilder.UseSqlite(@"Data Source=C:\Users\souma\Downloads\databasetp4.db");
                universityContextInstance = new UniversityContext(optionsBuilder.Options);
                return universityContextInstance;
            }
            else
            {
                return universityContextInstance;
            }
        }
    }
}
