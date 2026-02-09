using MathSystem.Application.Responses;
using MediatR;

namespace MathSystem.Application.Commands
{
    public class UploadExamCommand : IRequest<ExamResultResponse>
    {
        public UploadExamCommand()
        {

        }
        public string Xml { get; set; }

        public UploadExamCommand(string xml)
        {
            Xml = xml;
   
        }

    }
}
