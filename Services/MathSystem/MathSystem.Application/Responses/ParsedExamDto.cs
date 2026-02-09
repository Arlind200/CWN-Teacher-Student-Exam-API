namespace MathSystem.Application.Responses
{
    public class ParsedExamDto
    {
        public string TeacherId { get; set; }
        public string StudentId { get; set; }
        public string ExamId { get; set; }
        public List<ParsedTaskDto> Tasks { get; set; }
    }
}
