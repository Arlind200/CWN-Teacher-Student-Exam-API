namespace MathSystem.Application.Responses
{
    public class ExamTaskDto
    {
        public string Id { get; init; } = default!;
        public string TaskId { get; init; } = default!;
        public string Expression { get; init; } = default!;
        public int Expected { get; init; }
        public int Actual { get; init; }
        public bool IsCorrect { get; init; }
    }
}