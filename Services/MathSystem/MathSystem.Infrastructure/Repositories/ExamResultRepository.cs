using MathSystem.CORE.Entities;
using MathSystem.CORE.Repositories;
using MathSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MathSystem.Infrastructure.Repositories
{
    public class ExamResultRepository : IExamResultRepository
    {
        private readonly ExamResultDbContext _db;
        public ExamResultRepository(ExamResultDbContext db)
        {
            _db = db;
        }

        public Task<Exam?> GetExamResultById(string id, CancellationToken ct)
        {
            return _db.Exams
                .Include(x => x.Results)
                .FirstOrDefaultAsync(e => e.Id == id, ct);
        }

        public async Task AddAsync(Exam exam)
        {
            _db.Exams.Add(exam);
            await _db.SaveChangesAsync();
        }

        public async Task<Exam?> GetByIdAsync(string id)
        {
            return await _db.Exams
                .Include(x => x.Results)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Exam>> GetByTeacherAsync(string teacherId)
        {
            return await _db.Exams
                .Include(x => x.Results)
                .Where(x => x.TeacherId == teacherId)
                .ToListAsync();
        }

        public async Task<List<Exam>> GetByStudentAsync(string studentId)
        {
            return await _db.Exams
                .Include(x => x.Results)
                .Where(x => x.StudentId == studentId)
                .ToListAsync();
        }

        public async Task<List<Exam>> GetByExternalExamIdAsync(string externalExamId)
        {
            return await _db.Exams
                .Include(x => x.Results)
                .Where(e => e.ExamId == externalExamId)
                .ToListAsync();
        }
    }
}
