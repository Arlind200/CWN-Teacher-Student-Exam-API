using MathSystem.Application.Commands;
using MathSystem.Application.Interfaces;
using MathSystem.Application.Responses;
using MathSystem.CORE.Entities;
using MathSystem.CORE.Interface;
using MathSystem.CORE.Repositories;
using MediatR;

namespace MathSystem.Application.Handlers
{
    public class UploadExamCommandHandler :
        IRequestHandler<UploadExamCommand, ExamResultResponse>
    {
        private readonly IExamResultRepository _examRepository;
        private readonly IMathEvaluator _mathEvaluator;
        private readonly IXmlExamParser _xmlParser;

        public UploadExamCommandHandler(
           IExamResultRepository examRepository,
           IMathEvaluator mathEvaluator,
           IXmlExamParser xmlParser)
        {
            _examRepository = examRepository;
            _mathEvaluator = mathEvaluator;
            _xmlParser = xmlParser;
        }

        public async Task<ExamResultResponse> Handle(UploadExamCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (string.IsNullOrWhiteSpace(request.Xml)) throw new ArgumentNullException(nameof(request.Xml));

            var parsedExams = _xmlParser.Parse(request.Xml);
            var createdExamIds = new List<string>();
            int total = 0;
            int correct = 0;

            foreach (var examDto in parsedExams)
            {
                var exam = new Exam(
                    examDto.ExamId,
                    examDto.StudentId,
                    examDto.TeacherId);

                foreach (var task in examDto.Tasks)
                {
                    total++;

                    var expr = (task.Expression ?? string.Empty).Trim();
                    var eqIndex = expr.LastIndexOf('=');
                    if (eqIndex < 0) continue;

                    var left = expr.Substring(0, eqIndex).Trim();
                    var right = expr.Substring(eqIndex + 1).Trim();

                    if (!int.TryParse(right, out var expected)) continue;

                    var actual = _mathEvaluator.Calc(left);
                    if (expected == actual) correct++;

                    exam.AddTaskResult(
                        task.TaskId,
                        left,
                        expected,
                        actual);
                }

                await _examRepository.AddAsync(exam);
                createdExamIds.Add(exam.Id);
            }

            return ExamResultResponse.Success(createdExamIds, total, correct);
        }
    }
}
