using MathSystem.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MathSystem.Infrastructure.Data.Configurations
{
    public class ExamTaskResultConfiguration : IEntityTypeConfiguration<ExamTask>
    {
        public void Configure(EntityTypeBuilder<ExamTask> builder)
        {
            builder.ToTable("ExamTasks");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.TaskId).IsRequired();
            builder.Property(x => x.Expression).IsRequired();


        }
    }
}
