using MathSystem.Application.Responses;
using MediatR;

namespace MathSystem.Application.Queries
{
    // Query that requests all exams by the external ExamId (the Id coming from the XML)
    public class GetExamsByExamIdQuery : IRequest<IEnumerable<ExamDto>>
    {
        public string ExamId { get; init; }

        public GetExamsByExamIdQuery(string examId)
        {
            ExamId = examId;
        }
    }
}