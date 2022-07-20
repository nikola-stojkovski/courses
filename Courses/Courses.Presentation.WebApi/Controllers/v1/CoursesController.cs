namespace Courses.Presentation.WebApi.Controllers.v1
{
    using System.Net;
    using Courses.Core.Application.Features.CourseFeatures.Queries;
    using Courses.Core.Contracts.Models.Course;
    using Courses.Infrastructure.Persistence.Context;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Swashbuckle.AspNetCore.Annotations;

    [ApiVersion("1.0")]
    public class CoursesController : BaseApiController
    {
        private readonly ILogger<CoursesController> _logger;
        private readonly IApplicationDbContext _applicationDbContext;

        public CoursesController(ILogger<CoursesController> logger, IApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet("")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(IEnumerable<CourseDto>))]
        public async Task<IActionResult> GetCourses()
        {
            return Ok(await Mediator.Send(new GetCoursesQuery()));
        }
    }
}