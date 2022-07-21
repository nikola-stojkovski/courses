namespace Courses.Presentation.WebApi.Controllers.v1
{
    using System.Net;
    using Courses.Core.Application.Features.Application.Queries;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/courses/{courseUid}/applications")]
    public class ApplicationsController : BaseApiController
    {
        [HttpGet("")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(IEnumerable<int>))]
        public async Task<IActionResult> GetApplications([FromRoute] Guid courseUid)
        {
            return Ok(await Mediator.Send(new GetApplicationsQuery(courseUid)));
        }
    }
}
