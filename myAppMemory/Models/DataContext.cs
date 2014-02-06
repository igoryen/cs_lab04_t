using System.Data.Entity;

namespace CodeFirstOne.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=DataContext") { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<Course> Courses { get; set; }

        public System.Data.Entity.DbSet<CodeFirstOne.ViewModels.StudentFull> StudentFulls { get; set; }
    }
}