using MathSystem.CORE.Entities;

namespace MathSystem.CORE.Repositories
{
    public interface IExamResultRepository
    {
        Task AddAsync(Exam exam);
        Task<Exam?> GetExamResultById(string id, CancellationToken ct);
        Task<Exam?> GetByIdAsync(string id);
        Task<List<Exam>> GetByTeacherAsync(string teacherId);
        Task<List<Exam>> GetByStudentAsync(string studentId);

        // Return all Exam entities that have the given external ExamId
        Task<List<Exam>> GetByExternalExamIdAsync(string externalExamId);
    }
}
