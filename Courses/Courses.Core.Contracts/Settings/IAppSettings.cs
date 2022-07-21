namespace Courses.Core.Contracts.Settings
{
    public interface IAppSettings
    {
        /// <summary>
        /// Section with connection strings to the DB.
        /// </summary>
        ConnectionStrings ConnectionStrings { get; }
    }
}
