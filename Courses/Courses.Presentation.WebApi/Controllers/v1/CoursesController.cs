namespace Courses.Presentation.WebApi.Controllers.v1
{
    using System.Net;
    using Courses.Core.Application.Features.CourseFeatures.Commands;
    using Courses.Core.Application.Features.CourseFeatures.Queries;
    using Courses.Core.Contracts.Models.Course;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;

    [ApiVersion("1.0")]
    public class CoursesController : BaseApiController
    {
        [HttpGet("")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(IEnumerable<CourseDto>))]
        public async Task<IActionResult> GetCourses()
        {
            return Ok(await Mediator.Send(new GetCoursesQuery()));
        }
        
        [HttpPost("")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Guid))]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseRequest request)
        {
            return Ok(await Mediator.Send(new CreateCourseCommand(request)));
        }
    }
}