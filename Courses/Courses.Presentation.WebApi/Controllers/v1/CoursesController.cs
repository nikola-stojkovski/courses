namespace Courses.Presentation.WebApi.Controllers.v1
{
    using System.Net;
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

        [HttpGet("courses")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(IEnumerable<IEnumerable<DateTime>>))]
        public async Task<IEnumerable<IEnumerable<DateTime>>> GetCourses()
        {
            return await _applicationDbContext.Courses.Select(x => x.Dates).ToArrayAsync();
        }
    }
}