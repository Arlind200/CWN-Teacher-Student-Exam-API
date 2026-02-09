using MathSystem.CORE.Entities;
using Microsoft.EntityFrameworkCore;

namespace MathSystem.Infrastructure.Data
{
    public class ExamResultDbContext : DbContext
    {

        public DbSet<Teacher> Teachers => Set<Teacher>();
        public DbSet<Student> Students => Set<Student>();
        //    public DbSet<Exam> Exams => Set<Exam>();
        public DbSet<Exam> Exams => Set<Exam>();
        public DbSet<ExamTask> ExamTaskResults => Set<ExamTask>();

        public ExamResultDbContext(DbContextOptions<ExamResultDbContext> options)
             : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(ExamResultDbContext).Assembly);
        }
    }
}

