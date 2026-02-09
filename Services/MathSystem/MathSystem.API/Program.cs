
using MathSystem.Application.Commands;
using MathSystem.Application.Evaluator;
using MathSystem.Application.Interfaces;
using MathSystem.CORE.Interface;
using MathSystem.CORE.Repositories;
using MathSystem.Infrastructure.Data;
using MathSystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MathSystem.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var basePath = AppContext.BaseDirectory;
            var dbPath = Path.Combine(basePath, "Data", "exams.sqlite");
            var connectionString = $"Data Source={dbPath}";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend",
                    policy =>
                        policy.AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod());
            });
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UploadExamCommand).Assembly));
            builder.Services.AddDbContext<ExamResultDbContext>(options =>
            options.UseSqlite(connectionString));
            builder.Services.AddApiVersioning();

            builder.Services.AddScoped<IXmlExamParser, XmlExamParser>();
            builder.Services.AddScoped<IMathEvaluator, MathEvaluator>();
            builder.Services.AddScoped<IExamResultRepository, ExamResultRepository>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {

                var db = scope.ServiceProvider.GetRequiredService<ExamResultDbContext>();
                db.Database.Migrate();
            }
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.UseCors("AllowFrontend");
            app.MapControllers();

            app.Run();
        }
    }
}
