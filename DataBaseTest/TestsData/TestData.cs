using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;

namespace TestsData

{
    public static class TestData
    {
        private static ISettingsFile TestDataFile => new JsonSettingsFile("TestData\\testData.json");
        public static string ExpectedTimerValue => TestDataFile.GetValue<string>("TC4.ExpectedTimerValue");
        public static string AuthorId => TestDataFile.GetValue<string>("TC4.author_id");
        public static string ProjectId => TestDataFile.GetValue<string>("TC4.project_id");
    }
}
