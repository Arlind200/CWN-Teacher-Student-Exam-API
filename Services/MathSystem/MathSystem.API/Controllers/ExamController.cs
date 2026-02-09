using MathSystem.Application.Commands;
using MathSystem.Application.Queries;
using MathSystem.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MathSystem.API.Controllers
{
    public class ExamController : ApiController
    {
        private readonly IMediator _mediator;

        public ExamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST api/v1/Exam/upload
        [HttpPost("upload")]
        [ProducesResponseType(typeof(ExamResultResponse), (int)HttpStatusCode.Accepted)]
        public async Task<ActionResult<ExamResultResponse>> UploadExam(IFormFile file)
        {
            using var stream = file.OpenReadStream();
            using var reader = new StreamReader(stream);
            var xml = await reader.ReadToEndAsync();
            var command = new UploadExamCommand(xml);
            var result = await _mediator.Send(command);

            return Accepted(result);
        }

        // GET api/v1/Exam/results/{examId}
        [HttpGet("results/{examId}")]
        [ProducesResponseType(typeof(IEnumerable<ExamDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<IEnumerable<ExamDto>>> GetExamResultsByExamId(string examId)
        {
            var query = new GetExamsByExamIdQuery(examId);
            var result = await _mediator.Send(query);
            if (result == null || !result.Any()) return NotFound();
            return Ok(result);
        }

        // GET api/v1/Exam/student/{studentId}
        [HttpGet("student/{studentId}")]
        [ProducesResponseType(typeof(IEnumerable<ExamDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<IEnumerable<ExamDto>>> GetExamResultsByStudentId(string studentId)
        {
            var query = new GetExamsByStudentQuery(studentId);
            var result = await _mediator.Send(query);
            if (result == null || !result.Any()) return NotFound();
            return Ok(result);
        }
    }
}
