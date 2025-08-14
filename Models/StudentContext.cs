using Microsoft.EntityFrameworkCore;

namespace WebAppDotNetCoreCrudNew.Models
{
    public class StudentContext: DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
            
        }
        public DbSet<Student> Student { get; set; }
        public DbSet<Departments> Departments { get; set; }
    }
}
