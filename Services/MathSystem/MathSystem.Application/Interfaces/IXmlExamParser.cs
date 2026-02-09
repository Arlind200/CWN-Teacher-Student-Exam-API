using MathSystem.Application.Responses;

namespace MathSystem.Application.Interfaces
{
    public interface IXmlExamParser
    {
        IEnumerable<ParsedExamDto> Parse(string xml);
    }
}
