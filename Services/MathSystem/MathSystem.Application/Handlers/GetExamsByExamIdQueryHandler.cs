using MathSystem.Application.Queries;
using MathSystem.Application.Responses;
using MathSystem.CORE.Repositories;
using MediatR;

namespace MathSystem.Application.Handlers
{
    public class GetExamsByExamIdQueryHandler : IRequestHandler<GetExamsByExamIdQuery, IEnumerable<ExamDto>>
    {
        private readonly IExamResultRepository _repository;

        public GetExamsByExamIdQueryHandler(IExamResultRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ExamDto>> Handle(GetExamsByExamIdQuery request, CancellationToken cancellationToken)
        {
            var exams = await _repository.GetByExternalExamIdAsync(request.ExamId);

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

                var total = tasks.Count;
                var correct = tasks.Count(t => t.IsCorrect);

                return new ExamDto
                {
                    Id = e.Id,
                    ExamId = e.ExamId,
                    StudentId = e.StudentId,
                    TeacherId = e.TeacherId,
                    Tasks = tasks,
                    TotalTasks = total,
                    CorrectTasks = correct
                };
            });

            return dtos;
        }
    }
}