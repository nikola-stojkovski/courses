namespace Courses.Presentation.WebApi.Controllers.v1
{
    using System.Net;
    using Courses.Core.Application.Features.Application.Commands;
    using Courses.Core.Application.Features.Application.Queries;
    using Courses.Core.Contracts.Models.Application;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/courses/{courseUid}/applications")]
    public class ApplicationsController : BaseApiController
    {
        [HttpGet("")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(IReadOnlyList<ApplicationDto>))]
        public async Task<IActionResult> GetApplications([FromRoute] Guid courseUid)
        {
            return Ok(await Mediator.Send(new GetApplicationsQuery(courseUid)));
        }

        [HttpPost("")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Guid))]
        public async Task<IActionResult> CreateApplication([FromRoute] Guid courseUid, [FromBody] CreateApplicationRequest request)
        {
            return Ok(await Mediator.Send(new CreateApplicationCommand(courseUid: courseUid, request: request)));
        }
    }
}
