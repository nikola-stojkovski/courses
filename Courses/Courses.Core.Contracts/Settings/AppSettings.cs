namespace Courses.Core.Contracts.Settings
{
    using Microsoft.Extensions.Configuration;

    public class AppSettings : SettingsBase, IAppSettings
    {
        private ConnectionStrings _connectionStrings;

        public AppSettings(IConfiguration configuration) : base(configuration)
        {
        }

        public ConnectionStrings ConnectionStrings => _connectionStrings ??= GetSection<ConnectionStrings>(ConnectionStrings.CONNECTION_STRINGS);
    }
}
