using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;

namespace Configuration
{
    public static class TestConfig
    {
        private static ISettingsFile СonfigFile => new JsonSettingsFile("config.json");
        public static string Url => СonfigFile.GetValue<string>("URL");
        public static string Server => СonfigFile.GetValue<string>("DBConnection.server");
        public static string Port => СonfigFile.GetValue<string>("DBConnection.port");
        public static string Database => СonfigFile.GetValue<string>("DBConnection.database");
        public static string User => СonfigFile.GetValue<string>("DBConnection.user");
        public static string Password => СonfigFile.GetValue<string>("DBConnection.password");
        
    }
}
