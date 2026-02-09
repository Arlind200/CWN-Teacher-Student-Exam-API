namespace MathSystem.CORE.Entities
{
    public class Exam : BaseEntity
    {
        public string ExamId { get; set; }
        public string StudentId { get; set; }
        public string TeacherId { get; }

        private readonly List<ExamTask> _results = new();
        public IReadOnlyCollection<ExamTask> Results => _results;

        private Exam() { }

        public Exam(string examId, string studentId, string teacherId)
        {
            ExamId = examId;
            StudentId = studentId;
            TeacherId = teacherId;
        }

        // Use the entity Id as FK when creating child tasks so EF will attach correctly
        public void AddTaskResult(
            string taskId,
            string expression,
            int expected,
            int actual)
        {
            _results.Add(new ExamTask(
                this.Id,
                taskId,
                expression,
                expected,
                actual,
                expected == actual));
        }
    }
}
