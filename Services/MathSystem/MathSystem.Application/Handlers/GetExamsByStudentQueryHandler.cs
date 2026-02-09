using MathSystem.Application.Queries;
using MathSystem.Application.Responses;
using MathSystem.CORE.Repositories;
using MediatR;

namespace MathSystem.Application.Handlers
{
    public class GetExamsByStudentQueryHandler : IRequestHandler<GetExamsByStudentQuery, IEnumerable<ExamDto>>
    {
        private readonly IExamResultRepository _repository;

        public GetExamsByStudentQueryHandler(IExamResultRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ExamDto>> Handle(GetExamsByStudentQuery request, CancellationToken cancellationToken)
        {
            var exams = await _repository.GetByStudentAsync(request.StudentId);
            var dtos = exams.Select(e =>
            {
                var tasks = e.Results.Select(t => new ExamTaskDto
                {
                    Id = t.Id,
                    TaskId = t.TaskId,
                    Expression = t.Expression,
                    Expected = t.Expected,
                    Actual = t.Actual,
                    IsCorrect = t.IsCorrect
                }).ToList();

                return new ExamDto
                {
                    Id = e.Id,
                    ExamId = e.ExamId,
                    StudentId = e.StudentId,
                    TeacherId = e.TeacherId,
                    Tasks = tasks,
                    TotalTasks = tasks.Count,
                    CorrectTasks = tasks.Count(t => t.IsCorrect)
                    // ScorePercentage is a getter property, assumed to be calculated from CorrectTasks/TotalTasks
                };
            }).ToList();

            return dtos;
        }
    }
}