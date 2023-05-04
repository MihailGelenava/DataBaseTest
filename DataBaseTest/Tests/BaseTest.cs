using Aquality.Selenium.Browsers;
using DataBaseTest.SqlHelper;
using Configuration;
using DataBaseTest.Models;
using DataBaseTest.Utils;

namespace Tests
{
    public abstract class BaseTest
    {
        protected TestTableModel testTableModel;

        [SetUp]
        public void Setup()
        {
            SqlHelper.DBConnection.Open();
            testTableModel = new TestTableModel();

            testTableModel.AddColumn("name", TestContext.CurrentContext.Test.MethodName + " : " + TestContext.CurrentContext.Test.Properties.Get("Description"));
            testTableModel.AddColumn("method_name", TestContext.CurrentContext.Test.FullName);
            testTableModel.AddColumn("project_id", Randomize.GetRandomInt(6));
            testTableModel.AddColumn("session_id", Randomize.GetRandomInt(20));
            testTableModel.AddColumn("start_time", DateTime.Now);
            testTableModel.AddColumn("env", Environment.MachineName);
            testTableModel.AddColumn("browser", AqualityServices.Browser.BrowserName);

            AqualityServices.Browser.Maximize();
            AqualityServices.Browser.GoTo(TestConfig.Url);
            AqualityServices.Browser.WaitForPageToLoad();
        }

        [TearDown]
        public void TearDown()
        {
            testTableModel.AddColumn("end_time",DateTime.Now);
            try{
                testTableModel.AddColumn("status_id",(int)Enum.Parse(typeof(TestResultStatus), TestContext.CurrentContext.Result.Outcome.Status.ToString()));
            }
            catch (Exception)
            {
                testTableModel.AddColumn("status_id", (int)Enum.Parse(typeof(TestResultStatus), TestContext.CurrentContext.Result.Outcome.Label.ToString()));
            }

            AqualityServices.Browser.Quit();

            SqlHelper.InsertInTable("test", testTableModel.GetKeyValuePairs());
            SqlHelper.DBConnection.Close();
        }
    }
}
