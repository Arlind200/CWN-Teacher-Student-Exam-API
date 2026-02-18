namespace MathSystem.Application.Responses
{
    public class ExamResultResponse
    {
        public string? Id { get; set; }

        // Multiple exam Id
        public IEnumerable<string> Ids { get; set; } = Enumerable.Empty<string>();
        public int TotalTasks { get; set; }
        public int CorrectTasks { get; set; }
        public bool IsSuccess { get; set; }

        // Single Id
        public static ExamResultResponse Success(string examId, int total, int correct)
        {
            return new ExamResultResponse
            {
                Id = examId,
                Ids = new[] { examId },
                TotalTasks = total,
                CorrectTasks = correct,
                IsSuccess = true
            };
        }

        // Multiple Id response
        public static ExamResultResponse Success(IEnumerable<string> examIds, int total, int correct)
        {
            var ids = examIds?.ToList() ?? new List<string>();
            return new ExamResultResponse
            {
                Id = ids.FirstOrDefault(),
                Ids = ids,
                TotalTasks = total,
                CorrectTasks = correct,
                IsSuccess = true
            };
        }
    }
}
