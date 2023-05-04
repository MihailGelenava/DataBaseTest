using Aquality.Selenium.Browsers;
using DataBaseTest.SqlHelper;
using Forms;
using TestsData;
using MySql.Data.MySqlClient;

namespace Tests
{
    public class Tests : BaseTest
    {
        private WelcomePagePO welcomePage = new WelcomePagePO();
        private HomePagePO homePage = new HomePagePO();

        private CookiesFormPO cookiesForm = new CookiesFormPO();

        [Test, Description("Accept cookies on a Home page")]
        public void TC0003_AcceptCookies()
        {
            AqualityServices.Logger.Info("Step 1: Navigate to home page");

            AqualityServices.Logger.Info("Step 2: Click the link (in text 'Please click HERE to GO to the next page') to navigate the next page");

            welcomePage.ClickHomeLink();

            Assert.That(homePage.State.IsDisplayed, "Home page wasn't opened");

            AqualityServices.Logger.Info("Step 3: Click the button \"Not really, no\" to accept cookies");

            cookiesForm.AcceptCookie();

            Assert.That(!cookiesForm.State.IsDisplayed, "Cookies form wasn't closed");
        }

        [Test, Description("Verify that timer on a Home page starts from 00:00:00")]
        public void TC0004_ValidatingTimerValue()
        {
            AqualityServices.Logger.Info("Step 1: Navigate to home page");

            AqualityServices.Logger.Info("Step 2: Click the link (in text 'Please click HERE to GO to the next page') to navigate the next page");

            welcomePage.ClickHomeLink();

            Assert.That(homePage.State.IsDisplayed, "Home page wasn't opened");

            AqualityServices.Logger.Info($"Step 3: Check that timer starts from {TestData.ExpectedTimerValue}");

            Assert.That(homePage.GetTimerValue(), Is.EqualTo(TestData.ExpectedTimerValue), "Timer doesn't start from 00:00:00");
        }

        [Test]
        public void Test0002_SelectTenTestsWithDoubleDigitInId()
        {
            MySqlDataReader reader = SqlHelper.SelectFromTable("test", "*", "id REGEXP '(\\\\d)\\\\1+' limit 10");
            List<Dictionary<string, object>> rows = SqlHelper.GetRowsAsDictionaries(reader);

            foreach (var row in rows)
            {
                row["project_id"] = TestData.ProjectId;
                row["author_id"] = TestData.AuthorId;
                SqlHelper.UpdateDataInTable("test", row, $"id = {(long)row["id"]}");
            }
            foreach (var row in rows)
            {
                SqlHelper.DeleteFromTable("test", $"id = {(long)row["id"]}");
            }
        }
    }
}