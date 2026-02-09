using MathSystem.Application.Responses;
using MediatR;

namespace MathSystem.Application.Queries
{
    public class GetExamsByStudentQuery : IRequest<IEnumerable<ExamDto>>
    {
        public string StudentId { get; init; }

        public GetExamsByStudentQuery(string studentId)
        {
            StudentId = studentId;
        }
    }
}