namespace MathSystem.Application.Responses
{
    public class ExamDto
    {
        public string Id { get; init; } = default!;
        public string ExamId { get; init; } = default!;
        public string StudentId { get; init; } = default!;
        public string TeacherId { get; init; } = default!;
        public IEnumerable<ExamTaskDto> Tasks { get; init; } = Enumerable.Empty<ExamTaskDto>();

        // Score tracking properties
        public int TotalTasks { get; init; }
        public int CorrectTasks { get; init; }

        // Percentage convenience property (0..100)
        public double ScorePercentage => TotalTasks == 0 ? 0.0 : (double)CorrectTasks / TotalTasks * 100.0;
    }
}
