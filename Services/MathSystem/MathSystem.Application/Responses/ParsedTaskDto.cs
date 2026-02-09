namespace MathSystem.Application.Responses
{
    public class ParsedTaskDto
    {
        public string TaskId { get; set; }
        public string Expression { get; set; }
        public string ExamId { get; set; }
        public bool IsCorrect { get; internal set; }
    }
}
