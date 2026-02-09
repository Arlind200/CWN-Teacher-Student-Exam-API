using MathSystem.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MathSystem.Infrastructure.Data.Configurations
{
    public class ExamConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.ToTable("Exams");

            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Results)
                   .WithOne(x => x.Exam)
                   .HasForeignKey(x => x.ExamId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.ExamId).IsRequired();
            builder.Property(x => x.StudentId).IsRequired();
            builder.Property(x => x.TeacherId).IsRequired();


        }
    }
}
