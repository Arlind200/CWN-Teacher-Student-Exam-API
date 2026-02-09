namespace MathSystem.CORE.Entities
{
    public class TaskResult
    {
        public int ExamResultId { get; set; }
        public int ExamTaskId { get; set; }
        public int ActualResult { get; set; }
        public bool IsCorrect { get; set; }
    }
}
