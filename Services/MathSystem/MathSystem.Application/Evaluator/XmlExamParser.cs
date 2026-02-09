using MathSystem.Application.Interfaces;
using MathSystem.Application.Responses;
using System.Xml.Linq;

namespace MathSystem.Application.Evaluator
{
    public class XmlExamParser : IXmlExamParser
    {
        public IEnumerable<ParsedExamDto> Parse(string xml)
        {
            var doc = XDocument.Parse(xml);

            var teacherId = doc.Root?.Attribute("Id")?.Value ?? string.Empty;

            return doc.Descendants("Student").Select(student =>
            {
                var studentId = student.Attribute("Id")!.Value;
                var exam = student.Element("Exam")!;

                var tasks = exam.Elements("Task").Select(t =>
                {
                    // task value may include spaces/newlines; normalize it
                    var raw = t.Value?.Trim() ?? string.Empty;
                    return new ParsedTaskDto
                    {
                        TaskId = t.Attribute("Id")!.Value,
                        Expression = raw,
                        ExamId = exam.Attribute("Id")!.Value
                    };
                }).ToList();

                return new ParsedExamDto
                {
                    TeacherId = teacherId,
                    StudentId = studentId,
                    ExamId = exam.Attribute("Id")!.Value,
                    Tasks = tasks
                };
            });
        }
    }
}
