# Courses
### Technologies used
- .NET 6
- MSSQL
- Swagger
- EF 6
- Azure

### Application structure
In the Courses solution there are multiple projects:
- Courses.Core.Domain
- Courses.Core.Contracts
- Courses.Core.Application
- Courses.Infrastructure.Persistence
- Courses.Presentation.WebApi
- Courses.Tests.UnitTests

### Gettings started
__Courses.Presentation.WebApi.csproj__ should be set as a starting project.
Start the application with _Kestrel_ and the url for the Swagger will be "https://localhost:7218/swagger/index.html".
There is documentation for every route and model.
