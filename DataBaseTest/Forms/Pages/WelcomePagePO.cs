using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Forms
{
    internal class WelcomePagePO : Form
    {
        private ILink HomeLink => ElementFactory.GetLink(By.ClassName("start__link"), "start link");

        public WelcomePagePO() : base(By.XPath("//div[@class='view__row']//button"), "Welcome Page") { }

        public void ClickHomeLink() => HomeLink.Click();
    }
}
